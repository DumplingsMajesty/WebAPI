namespace WebApi007.Configurations
{
    public class SqlConfigurationSource : IConfigurationSource
    {
        public string SqlConnection;
        public string Query;

        public SqlConfigurationSource(string sqlConnection, string query)
        {
            this.SqlConnection = sqlConnection;
            this.Query = query;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new SqlConfigurationProvider(this);
        }
    }
}
