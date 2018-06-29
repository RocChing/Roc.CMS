using Abp.Dependency;
using Castle.Windsor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.Diagnostics;
using IMyLogger = Castle.Core.Logging.ILogger;
using IMyLoggerFactory = Castle.Core.Logging.ILoggerFactory;
using System.Collections.Generic;

namespace Roc.CMS.Logging
{
    public class EFLogger : ILogger
    {
        private readonly string categoryName;
        private IMyLogger _logger;
        public EFLogger(string categoryName)
        {
            this._logger = IocManager.Instance.Resolve<IMyLoggerFactory>().Create("SQLLoger");
            this.categoryName = categoryName;
        }

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (categoryName== DbLoggerCategory.Database.Command.Name && logLevel == LogLevel.Information)
            {
                //var kv = state as KeyValuePair<string, object>;
                //if (kv != null)
                //{

                //}
                var logContent = formatter(state, exception);
                _logger.Info(logContent, exception);
            }
        }

        public IDisposable BeginScope<TState>(TState state) => null;
    }
}
