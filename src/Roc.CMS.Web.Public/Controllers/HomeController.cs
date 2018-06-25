using Microsoft.AspNetCore.Mvc;
using Roc.CMS.Web.Controllers;

namespace Roc.CMS.Web.Public.Controllers
{
    public class HomeController : AbpZeroTemplateControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}