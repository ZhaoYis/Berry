using System.Collections.ObjectModel;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Description;
using System.Web.Http.Routing;
using Berry.SOA.API.Attributes;

namespace Berry.SOA.API.Explorer
{
    /// <summary>
    /// 自定义API探测器
    /// </summary>
    public class CustomApiExplorer : ApiExplorer
    {
        public CustomApiExplorer(HttpConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Action探测
        /// </summary>
        /// <param name="actionVariableValue"></param>
        /// <param name="actionDescriptor"></param>
        /// <param name="route"></param>
        /// <returns></returns>
        public override bool ShouldExploreAction(string actionVariableValue, HttpActionDescriptor actionDescriptor, IHttpRoute route)
        {
            //忽略打了IngoreAction特性的方法
            var attributes = actionDescriptor.GetCustomAttributes<IngoreActionAttribute>();
            if (attributes.Count > 0) return false;

            return base.ShouldExploreAction(actionVariableValue, actionDescriptor, route);
        }

        /// <summary>
        /// Controller探测
        /// </summary>
        /// <param name="controllerVariableValue"></param>
        /// <param name="controllerDescriptor"></param>
        /// <param name="route"></param>
        /// <returns></returns>
        public override bool ShouldExploreController(string controllerVariableValue, HttpControllerDescriptor controllerDescriptor, IHttpRoute route)
        {
            //controllerVariableValue = controllerVariableValue.Replace(".", "/");

            return base.ShouldExploreController(controllerVariableValue, controllerDescriptor, route);
        }

    }
}