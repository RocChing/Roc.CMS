using Abp.Authorization;
using Roc.CMS.Authorization.Roles;
using Roc.CMS.Authorization.Users;

namespace Roc.CMS.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
