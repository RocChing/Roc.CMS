using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Roc.CMS.Web.Areas.Sys.Models.Layout;
using Roc.CMS.Web.Session;
using Roc.CMS.Web.Views;

namespace Roc.CMS.Web.Areas.Sys.Views.Shared.Components.SysFooter
{
    public class SysFooterViewComponent : AbpZeroTemplateViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public SysFooterViewComponent(IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var footerModel = new FooterViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync()
            };

            return View(footerModel);
        }
    }
}
