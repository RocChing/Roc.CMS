using Abp.Auditing;
using Microsoft.AspNetCore.Mvc;

namespace Roc.CMS.Web.Controllers
{
    public class HomeController : AbpZeroTemplateControllerBase
    {
        [DisableAuditing]
        public IActionResult Index()
        {
            return Redirect("/swagger");
        }
    }
}
