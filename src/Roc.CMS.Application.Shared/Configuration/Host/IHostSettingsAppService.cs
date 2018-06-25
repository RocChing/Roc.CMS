using System.Threading.Tasks;
using Abp.Application.Services;
using Roc.CMS.Configuration.Host.Dto;

namespace Roc.CMS.Configuration.Host
{
    public interface IHostSettingsAppService : IApplicationService
    {
        Task<HostSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(HostSettingsEditDto input);

        Task SendTestEmail(SendTestEmailInput input);
    }
}
