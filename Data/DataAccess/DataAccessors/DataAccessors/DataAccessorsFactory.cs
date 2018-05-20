using DataAccessMeta;
using iStore.Data.Model.DataModelMeta;
using System;

namespace DataAccessors
{
    public class DataAccessorsFactory
    {
        public static DataAccessorsFactory Instance = new DataAccessorsFactory();

        public DataAccessor<DataType, SelectionType> GetDataAccessor<DataType, SelectionType>()
            where DataType : DataItem
            where SelectionType : DataSelection
        {
            throw new NotImplementedException();
        }
    }
}
