using iStore.Data.DataAccess.DataAccessMeta;
using iStore.Data.DataModel.DataModelMeta;
using System;

namespace DataAccessors
{
    public class DataAccessorsFactory
    {
        public static DataAccessorsFactory Instance = new DataAccessorsFactory();

        public DataAccessor<DataType, SelectionType> GetDataAccessor<DataType, SelectionType>()
            where DataType : IDataItem
            where SelectionType : IDataSelection
        {
            throw new NotImplementedException();
        }
    }
}
