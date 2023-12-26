namespace WebApi008.Logs
{
    [ProviderAlias("SqlLog")]
    public class SqlLoggerProvider :  ILoggerProvider
    {
        private readonly string connection;

        public SqlLoggerProvider(string connection) { 
            this.connection = connection;
        }

        public ILogger CreateLogger(string categoryName,string connection)
        {
            return new SqlLogger(categoryName,connection);
        }

        public ILogger CreateLogger(string categoryName)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            
        }
    }
}