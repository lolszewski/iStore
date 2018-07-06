using iStore.Data.DataAccess.DataAccessMeta;
using iStore.Data.DataModel.DataModelMeta;
using System;

namespace iStore.Data.Access
{
    public class DataAccessorsFactory : IDataAccessorsFactory
    {
        public IDataAccessor<DataType, SelectionType> GetDataAccessor<DataType, SelectionType>()
            where DataType : IDataItem
            where SelectionType : IDataSelection
        {
            throw new NotImplementedException();
        }
    }
}
