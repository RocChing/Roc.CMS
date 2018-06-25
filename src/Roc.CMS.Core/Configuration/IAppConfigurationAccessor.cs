using Microsoft.Extensions.Configuration;

namespace Roc.CMS.Configuration
{
    public interface IAppConfigurationAccessor
    {
        IConfigurationRoot Configuration { get; }
    }
}
