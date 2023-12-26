
namespace WebApi007.Configurations
{
    internal class SqlConfigurationProvider : ConfigurationProvider
    {
        private SqlConfigurationSource sqlConfigurationSource;

        public SqlConfigurationProvider(SqlConfigurationSource sqlConfigurationSource)
        {
            this.sqlConfigurationSource = sqlConfigurationSource;
        }

        public override void Load()
        {
            var a1 = sqlConfigurationSource.SqlConnection;
            var a2 = sqlConfigurationSource.Query;

            Data.Add("MyKey","MyKeyFromSQL");
        }
    }
}