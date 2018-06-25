using Abp.AutoMapper;
using Roc.CMS.Authorization.Roles.Dto;
using Roc.CMS.Web.Areas.Sys.Models.Common;

namespace Roc.CMS.Web.Areas.Sys.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class CreateOrEditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool IsEditMode
        {
            get { return Role.Id.HasValue; }
        }

        public CreateOrEditRoleModalViewModel(GetRoleForEditOutput output)
        {
            output.MapTo(this);
        }
    }
}