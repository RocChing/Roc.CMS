using Abp.Application.Services;
using Roc.CMS.Dto;
using Roc.CMS.Logging.Dto;

namespace Roc.CMS.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
