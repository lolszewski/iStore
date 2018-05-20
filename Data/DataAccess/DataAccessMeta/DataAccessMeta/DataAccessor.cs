using iStore.Data.Model.DataModelMeta;

namespace DataAccessMeta
{
    public interface DataAccessor<DataType, DataSelectionType> 
        where DataType: DataItem
        where DataSelectionType: DataSelection
    {
        DataType get(DataSelectionType selection);
    }
}
