using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Collections.Concurrent;

namespace iStore.Data.Access.Sources.MsSql.MsSqlEntLibDataAccess
{
    public class EntLibCachedDatabaseContainer
    {
        public static readonly EntLibCachedDatabaseContainer Instance;
        
        private ConcurrentDictionary<string, Database> Databases;

        private EntLibCachedDatabaseContainer() { }

        static EntLibCachedDatabaseContainer()
        {
            Instance = new EntLibCachedDatabaseContainer();
            Instance.Databases = new ConcurrentDictionary<string, Database>();
        }

        public Database GetDatabase(string connectionString)
        {
            if (!Databases.ContainsKey(connectionString))
            {
                var createdDatabase = EntLibDatabaseBuilder.Instance.Build(connectionString);
                Databases.TryAdd(connectionString, createdDatabase);
            }

            Databases.TryGetValue(connectionString, out var database);

            return database;
        }
    }
}
