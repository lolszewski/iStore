using iStore.Data.DataModel.DataModelMeta;

namespace iStore.Data.DataAccess.DataAccessMeta
{
    public interface IDataAccessorsFactory
    {
        IDataAccessor<DataType, SelectionType> GetDataAccessor<DataType, SelectionType>()
            where DataType : IDataItem
            where SelectionType : IDataSelection;
    }
}
