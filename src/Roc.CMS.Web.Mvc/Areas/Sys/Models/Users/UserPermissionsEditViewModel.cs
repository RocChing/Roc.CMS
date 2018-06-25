using Abp.AutoMapper;
using Roc.CMS.Authorization.Users;
using Roc.CMS.Authorization.Users.Dto;
using Roc.CMS.Web.Areas.Sys.Models.Common;

namespace Roc.CMS.Web.Areas.Sys.Models.Users
{
    [AutoMapFrom(typeof(GetUserPermissionsForEditOutput))]
    public class UserPermissionsEditViewModel : GetUserPermissionsForEditOutput, IPermissionsEditViewModel
    {
        public User User { get; private set; }

        public UserPermissionsEditViewModel(GetUserPermissionsForEditOutput output, User user)
        {
            User = user;
            output.MapTo(this);
        }
    }
}