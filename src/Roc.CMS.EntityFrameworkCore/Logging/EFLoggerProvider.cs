using Microsoft.Extensions.Logging;

namespace Roc.CMS.Logging
{
    public class EFLoggerProvider : ILoggerProvider
    {
        public EFLoggerProvider()
        {
        }

        public ILogger CreateLogger(string categoryName) => new EFLogger(categoryName);

        public void Dispose()
        {

        }
    }
}
