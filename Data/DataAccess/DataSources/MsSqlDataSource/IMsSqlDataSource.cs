using iStore.Data.DataModel.DataModelMeta;

namespace iStore.Data.Access.DataSources.MsSql.MsSqlDataSourceMeta
{
    public interface IMsSqlDataSource : IDataSource
    {
        string GetConnectionString();
    }
}
