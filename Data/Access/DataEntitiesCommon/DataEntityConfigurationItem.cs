using System;
using DataEntitiesCommonMeta;
using iStore.Data.Access.DataAccessMeta;

namespace iStore.Data.Access.DataEntitiesCommon
{
    public class DataEntityConfigurationItem : IDataEntityConfigurationItem
    {
        public Type DataItemType { get; set; }

        public IDataAccess DataAccess { get; set; }

        public IDataLocation DataLocation { get; set; }

        public void Configure(Type dataItemType, IDataAccess dataAccess, IDataLocation dataLocation)
        {
            DataItemType = dataItemType;
        }

        public IDataAccess GetDataAccess()
        {
            return DataAccess;
        }
    }
}
