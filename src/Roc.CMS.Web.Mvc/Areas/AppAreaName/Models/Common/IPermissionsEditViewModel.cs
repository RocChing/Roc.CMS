using System.Collections.Generic;
using Roc.CMS.Authorization.Permissions.Dto;

namespace Roc.CMS.Web.Areas.AppAreaName.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }

        List<string> GrantedPermissionNames { get; set; }
    }
}