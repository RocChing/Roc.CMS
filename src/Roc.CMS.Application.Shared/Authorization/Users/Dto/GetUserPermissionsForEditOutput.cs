using System.Collections.Generic;
using Roc.CMS.Authorization.Permissions.Dto;

namespace Roc.CMS.Authorization.Users.Dto
{
    public class GetUserPermissionsForEditOutput
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}