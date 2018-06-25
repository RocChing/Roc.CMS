using Abp.Application.Navigation;

namespace Roc.CMS.Web.Areas.Sys.Models.Layout
{
    public class MenuViewModel
    {
        public UserMenu Menu { get; set; }

        public string CurrentPageName { get; set; }
    }
}