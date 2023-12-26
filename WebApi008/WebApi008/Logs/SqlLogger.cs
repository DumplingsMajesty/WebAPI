using System.Diagnostics;
using System.Runtime.Serialization;

namespace WebApi008.Logs
{
    [Serializable]
    public sealed class SqlLogger : ILogger
    {
        private string categoryname;
        private string connection;
        public SqlLogger(string categoryname, string connection)
        {
            this.categoryname = categoryname;
            this.connection = connection;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return NullScope.Instance;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return Debugger.IsAttached && logLevel != LogLevel.None;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            if(formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            string message = formatter(state, exception);

            if (string.IsNullOrEmpty(message))
            {
                return;

            }

            message = $"{logLevel}：{message}";

            if(exception!= null)
            {
                message += Environment.NewLine + Environment.NewLine + exception;
            }

            var a1 = connection;

            Console.WriteLine(message,categoryname);
        }
    }
}