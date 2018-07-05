namespace iStore.Data.DataModel.DataModelMeta
{
    public interface IDataItem
    {
        IDataSource GetDataSource();

        IDataSelection GetDataSelection();
    }
}
