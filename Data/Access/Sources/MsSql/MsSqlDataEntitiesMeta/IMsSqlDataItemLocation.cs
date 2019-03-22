using iStore.Data.Access.DataAccessMeta;

namespace iStore.Data.Access.Sources.MsSql.MsSqlDataItemsMeta
{
    public interface IMsSqlDataItemLocation : IDataLocation
    {
        string GetConnectionString();

        string GetDatabaseName();

        string GetTableName();

        void SetConnectionString(string connectionString);

        void SetDatabaseName(string databaseName);

        void SetTableName(string tableName);
    }
}
