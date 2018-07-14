using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Configuration;

namespace iStore.Data.Access.Sources.MsSql.MsSqlEntLibDataAccess
{
    public class EntLibDatabaseBuilder
    {
        public static readonly EntLibDatabaseBuilder Instance;

        private EntLibDatabaseBuilder() { }

        static EntLibDatabaseBuilder()
        {
            Instance = new EntLibDatabaseBuilder();
        }

        public Database Build(string connectionString)
        {
            var connectionStringsSection = new ConnectionStringsSection();
            var connectionStringSection = new ConnectionStringSettings
            {
                Name = connectionString,
                ProviderName = "System.Data.SqlClient",
                ConnectionString = connectionString
            };
            connectionStringsSection.ConnectionStrings.Add(connectionStringSection);

            IConfigurationSource entLibConfigurationSource = new DictionaryConfigurationSource(); ;
            entLibConfigurationSource.Add("connectionStrings", connectionStringsSection);

            var databaseProviderFactory = new DatabaseProviderFactory(entLibConfigurationSource);
            var database = databaseProviderFactory.Create("");

            return database;
        }
    }
}
