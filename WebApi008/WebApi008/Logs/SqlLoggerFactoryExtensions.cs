using Microsoft.Extensions.DependencyInjection.Extensions;

namespace WebApi008.Logs
{
    public static class SqlLoggerFactoryExtensions
    {
        public static ILoggingBuilder AddSqlLog(this ILoggingBuilder builder,string connection)
        {
            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<ILoggerProvider, SqlLoggerProvider>(x=>new SqlLoggerProvider(connection)));

            return builder;
        }
    }
}
