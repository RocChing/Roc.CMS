using System.Collections.Generic;
using MvvmHelpers;
using Roc.CMS.Models.NavigationMenu;

namespace Roc.CMS.Services.Navigation
{
    public interface IMenuProvider
    {
        ObservableRangeCollection<NavigationMenuItem> GetAuthorizedMenuItems(Dictionary<string, string> grantedPermissions);
    }
}