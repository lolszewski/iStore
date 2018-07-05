using iStore.Data.DataModel.DataModelMeta;

namespace iStore.Data.DataAccess.DataAccessMeta
{
    public interface DataAccessor<DataType, DataSelectionType> 
        where DataType: IDataItem
        where DataSelectionType: IDataSelection
    {
        DataType get(DataSelectionType selection);
    }
}
