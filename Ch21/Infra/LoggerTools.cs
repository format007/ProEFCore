using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ch21.Infra
{
    public static class LoggerTools
    {
        public static ILoggerFactory AddFileLogger(this ILoggerFactory factory, string filePath)
        {
            factory.AddProvider(new FileLoggerProvider(filePath));
            return factory;
        }
    }
}
