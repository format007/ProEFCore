using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ch21.Infra
{
    public class FileLoggerProvider : ILoggerProvider
    {
        private string fileName;

        public FileLoggerProvider(string fileName) => this.fileName = fileName;

        public ILogger CreateLogger(string categoryName) => new FileLogger(fileName);

        public void Dispose()
        {
            
        }
    }
}
