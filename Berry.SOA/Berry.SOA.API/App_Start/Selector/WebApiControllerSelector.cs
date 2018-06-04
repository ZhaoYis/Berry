using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Http.Routing;

namespace Berry.SOA.API.Selector
{
    /// <summary>
    /// WebApi版本控制
    /// </summary>
    public class WebApiControllerSelector : IHttpControllerSelector
    {
        private const string VersionKey = "version";
        private const string ControllerKey = "controller";

        private readonly HttpConfiguration _configuration;
        private readonly Lazy<Dictionary<string, HttpControllerDescriptor>> _controllers;
        private readonly HashSet<string> _duplicates;

        private WebApiControllerSelector()
        {
        }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="config"></param>
        public WebApiControllerSelector(HttpConfiguration config)
        {
            _configuration = config;
            _duplicates = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            _controllers = new Lazy<Dictionary<string, HttpControllerDescriptor>>(InitializeControllerDictionary);
        }

        /// <summary>
        /// 初始化字典
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, HttpControllerDescriptor> InitializeControllerDictionary()
        {
            var dictionary = new Dictionary<string, HttpControllerDescriptor>(StringComparer.OrdinalIgnoreCase);

            // Create a lookup table where key is "namespace.controller". The value of "namespace" is the last
            // segment of the full namespace. For example:
            // MyApplication.Controllers.V1.ProductsController => "V1.Products"
            IAssembliesResolver assembliesResolver = _configuration.Services.GetAssembliesResolver();
            IHttpControllerTypeResolver controllersResolver = _configuration.Services.GetHttpControllerTypeResolver();

            ICollection<Type> controllerTypes = controllersResolver.GetControllerTypes(assembliesResolver);

            foreach (Type t in controllerTypes)
            {
                if (t.Namespace != null)
                {
                    var segments = t.Namespace.Split(Type.Delimiter);

                    // For the dictionary key, strip "Controller" from the end of the type name.
                    // This matches the behavior of DefaultHttpControllerSelector.
                    var controllerName = t.Name.Remove(t.Name.Length - DefaultHttpControllerSelector.ControllerSuffix.Length);
                    string version = segments[segments.Length - 1];
                    var key = String.Format(CultureInfo.InvariantCulture, "{0}.{1}", version, controllerName);
                    if (version == "Controllers")
                    {
                        key = String.Format(CultureInfo.InvariantCulture, "{0}", controllerName);
                    }
                    // Check for duplicate keys.
                    if (dictionary.Keys.Contains(key))
                    {
                        _duplicates.Add(key);
                    }
                    else
                    {
                        dictionary[key] = new HttpControllerDescriptor(_configuration, t.Name, t);
                    }
                }
            }

            // Remove any duplicates from the dictionary, because these create ambiguous matches. 
            // For example, "Foo.V1.ProductsController" and "Bar.V1.ProductsController" both map to "v1.products".
            foreach (string s in _duplicates)
            {
                dictionary.Remove(s);
            }
            return dictionary;
        }

        /// <summary>
        /// 取路由相应值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="routeData"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private static T GetRouteVariable<T>(IHttpRouteData routeData, string name)
        {
            object result;
            if (routeData.Values.TryGetValue(name, out result))
            {
                return (T)result;
            }
            return default(T);
        }

        /// <summary>
        /// 匹配相应路由
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            IHttpRouteData routeData = request.GetRouteData();
            if (routeData == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            //获取版本信息
            string version = GetRouteVariable<string>(routeData, VersionKey);
            if (string.IsNullOrEmpty(version))
            {
                version = GetVersionFromAcceptHeaderVersion(request);
            }

            //获取控制器名称
            string controllerName = GetRouteVariable<string>(routeData, ControllerKey);
            if (string.IsNullOrEmpty(controllerName))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                // Find a matching controller.
                string key = String.Format(CultureInfo.InvariantCulture, "{0}", controllerName);
                if (!string.IsNullOrEmpty(version))
                {
                    key = String.Format(CultureInfo.InvariantCulture, "{0}.{1}", version.ToUpper(), controllerName);
                }

                HttpControllerDescriptor controllerDescriptor;
                if (_controllers.Value.TryGetValue(key, out controllerDescriptor))
                {
                    return controllerDescriptor;
                }
                else if (_duplicates.Contains(key))
                {
                    throw new HttpResponseException(
                        request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                            "找到了与此请求相匹配的多个控制器."));
                }
                else
                {
                    throw new HttpResponseException(
                        request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "找不到请求资源，请检查请求地址是否正确."));

                    //throw new HttpResponseException(HttpStatusCode.NotFound);
                }
            }
        }

        /// <summary>
        /// 获取映射信息
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, HttpControllerDescriptor> GetControllerMapping()
        {
            return _controllers.Value;
        }

        /// <summary>
        /// 从请求头里面获取版本信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private string GetVersionFromAcceptHeaderVersion(HttpRequestMessage request)
        {
            if (request.Headers.Contains(VersionKey))
            {
                string versionHeader = request.Headers.GetValues(VersionKey).FirstOrDefault();
                if (versionHeader != null)
                {
                    return versionHeader;
                }
            }

            var acceptHeader = request.Headers.Accept;
            foreach (var mime in acceptHeader)
            {
                if (mime.MediaType == "application/json" || mime.MediaType == "text/html")
                {
                    NameValueHeaderValue version = mime.Parameters
                        .FirstOrDefault(v => v.Name.Equals(VersionKey, StringComparison.OrdinalIgnoreCase));

                    if (version != null)
                    {
                        return version.Value;
                    }
                    return string.Empty;
                }
            }
            return string.Empty;
        }
    }
}