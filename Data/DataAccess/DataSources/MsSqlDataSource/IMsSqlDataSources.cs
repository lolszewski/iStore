using iStore.Data.DataModel.DataModelMeta;

namespace iStore.Data.Access.DataSources.MsSql.MsSqlDataSourceMeta
{
    public interface IMsSqlDataSources : IDataSource
    {
        string GetConnectionString();
    }
}
