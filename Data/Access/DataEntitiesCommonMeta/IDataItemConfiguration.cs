using iStore.Core.Meta;
using iStore.Data.Access.DataAccessMeta;
using System;

namespace iStore.Data.Access.DataItemsCommonMeta
{
    public interface IDataItemConfiguration : IService
    {
        void Configure(Type dataItemType, IDataAccess dataAccess, IDataLocation dataLocation);

        IDataAccess GetDataAccess();
    }
}
