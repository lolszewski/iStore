using iStore.Data.Access.DataAccessMeta;

namespace iStore.Data.Access.Sources.MsSql.MsSqlDataEntitiesMeta
{
    public interface IMsSqlDataEntityLocation : IDataLocation
    {
        string GetConnectionString();

        string GetDatabaseName();

        string GetTableName();

        void SetConnectionString(string connectionString);

        void SetDatabaseName(string databaseName);

        void SetTableName(string tableName);
    }
}
