using System.Threading.Tasks;
using Abp.Application.Services;
using Roc.CMS.Configuration.Tenants.Dto;

namespace Roc.CMS.Configuration.Tenants
{
    public interface ITenantSettingsAppService : IApplicationService
    {
        Task<TenantSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(TenantSettingsEditDto input);

        Task ClearLogo();

        Task ClearCustomCss();
    }
}
