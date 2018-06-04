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

        public HelpController()
            : this(GlobalConfiguration.Configuration)
        {
        }

        public HelpController(HttpConfiguration config)
        {
            Configuration = config;
        }

        public HttpConfiguration Configuration { get; private set; }

        public ActionResult Index()
        {
            IDocumentationProvider provider = Configuration.Services.GetDocumentationProvider();
            ViewBag.DocumentationProvider = provider;

            Collection<ApiDescription> descriptions = Configuration.Services.GetApiExplorer().ApiDescriptions;
            
            //NotApiMethodAttribute attr = Attribute.GetCustomAttribute(fieldInfo, typeof(NotApiMethodAttribute), false) as NotApiMethodAttribute;
            //descriptions[1].ActionDescriptor.ActionName
            //"Logger"

            return View(descriptions);
        }

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