using Abp.Application.Navigation;

namespace Roc.CMS.Web.Areas.Sys.Views.Shared.Components.SysSideBar
{
    public class UserMenuItemViewModel
    {
        public UserMenuItem MenuItem { get; set; }

        public string CurrentPageName { get; set; }

        public int MenuItemIndex { get; set; }

        public bool RootLevel { get; set; }
    }
}
