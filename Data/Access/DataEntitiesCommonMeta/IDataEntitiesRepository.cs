using DataEntitiesCommonMeta;
using iStore.Data.Access.DataAccessMeta;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iStore.Data.Access.DataEntitiesCommon
{
    public interface IDataEntitiesRepository
    {
        Task<IDataIdentifier> Create(IDataItem entity);

        Task<IDataItem> Read<T>(IDataIdentifier identifier);

        Task<IEnumerable<IDataItem>> ReadMany<T>(IDataSelection query);

        Task<IDataItem> Update(IDataItem entity);

        Task Delete<T>(IDataSelection query);

        void Configure<T>(IDataEntityConfigurationItem configuration) where T : IDataItem;
    }
}
