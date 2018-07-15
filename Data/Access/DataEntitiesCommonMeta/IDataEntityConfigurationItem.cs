using iStore.Data.Access.DataAccessMeta;
using System;

namespace DataEntitiesCommonMeta
{
    public interface IDataEntityConfigurationItem
    {
        void Configure(Type dataItemType, IDataAccess dataAccess, IDataLocation dataLocation);

        IDataAccess GetDataAccess();
    }
}
