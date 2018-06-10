using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using Berry.SOA.API.Areas.HelpPage.ModelDescriptions;
using Berry.SOA.API.Areas.HelpPage.Models;
using WebGrease.Css.Extensions;

namespace Berry.SOA.API.Areas.HelpPage.Controllers
{
    /// <summary>
    /// The controller that will handle requests for the help page.
    /// </summary>
    public class HelpController : Controller
    {
        private const string ErrorViewName = "Error";

        public HelpController(): this(GlobalConfiguration.Configuration)
        {
        }

        public HelpController(HttpConfiguration config)
        {
            Configuration = config;
        }

        public HttpConfiguration Configuration { get; private set; }

        /// <summary>
        /// 接口列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            IDocumentationProvider provider = Configuration.Services.GetDocumentationProvider();
            ViewBag.DocumentationProvider = provider;

            Collection<ApiDescription> descriptions = Configuration.Services.GetApiExplorer().ApiDescriptions;

            return View(descriptions);
        }

        /// <summary>
        /// 接口详细信息
        /// </summary>
        /// <param name="apiId"></param>
        /// <returns></returns>
        public ActionResult Api(string apiId)
        {
            if (!String.IsNullOrEmpty(apiId))
            {
                HelpPageApiModel apiModel = Configuration.GetHelpPageApiModel(apiId);
                if (apiModel != null)
                {
                    return View(apiModel);
                }
            }

            return View(ErrorViewName);
        }

        /// <summary>
        /// 实体资源
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        public ActionResult ResourceModel(string modelName)
        {
            if (!String.IsNullOrEmpty(modelName))
            {
                ModelDescriptionGenerator modelDescriptionGenerator = Configuration.GetModelDescriptionGenerator();
                ModelDescription modelDescription;
                if (modelDescriptionGenerator.GeneratedModels.TryGetValue(modelName, out modelDescription))
                {
                    return View(modelDescription);
                }
            }

            return View(ErrorViewName);
        }
    }
}