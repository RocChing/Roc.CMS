using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Roc.CMS.Authorization.Permissions.Dto;

namespace Roc.CMS.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
