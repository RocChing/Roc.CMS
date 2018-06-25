using System.Threading.Tasks;
using Abp.Application.Services;
using Roc.CMS.Install.Dto;

namespace Roc.CMS.Install
{
    public interface IInstallAppService : IApplicationService
    {
        Task Setup(InstallDto input);

        AppSettingsJsonDto GetAppSettingsJson();

        CheckDatabaseOutput CheckDatabase();
    }
}