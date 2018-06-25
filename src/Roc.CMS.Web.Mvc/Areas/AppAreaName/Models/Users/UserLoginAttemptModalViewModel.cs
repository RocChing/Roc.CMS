using System.Collections.Generic;
using Roc.CMS.Authorization.Users.Dto;

namespace Roc.CMS.Web.Areas.AppAreaName.Models.Users
{
    public class UserLoginAttemptModalViewModel
    {
        public List<UserLoginAttemptDto> LoginAttempts { get; set; }
    }
}