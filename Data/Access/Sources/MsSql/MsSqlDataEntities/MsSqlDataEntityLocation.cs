using iStore.Data.Access.Sources.MsSql.MsSqlDataEntitiesMeta;

namespace iStore.Data.Access.Sources.MsSql.MsSqlDataEntities
{
    public class MsSqlDataEntityLocation : IMsSqlDataEntityLocation
    {
        private string ConnectionString { get; set; }

        private string DatabaseName { get; set; }

        private string TableName { get; set; }

        public string GetConnectionString()
        {
            return ConnectionString;
        }

        public string GetDatabaseName()
        {
            return DatabaseName;
        }

        public string GetTableName()
        {
            return TableName;
        }

        public void SetConnectionString(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public void SetDatabaseName(string databaseName)
        {
            DatabaseName = databaseName;
        }

        public void SetTableName(string tableName)
        {
            TableName = tableName;
        }
    }
}
