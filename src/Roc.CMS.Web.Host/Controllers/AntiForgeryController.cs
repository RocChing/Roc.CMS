using Microsoft.AspNetCore.Antiforgery;

namespace Roc.CMS.Web.Controllers
{
    public class AntiForgeryController : AbpZeroTemplateControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
