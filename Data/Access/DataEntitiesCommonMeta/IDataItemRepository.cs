using iStore.Core.Meta;
using iStore.Data.Access.DataAccessMeta;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iStore.Data.Access.DataItemsCommonMeta
{
    public interface IDataItemRepository
        <
            DataItemType,
            DataIdentifierType,
            DataGetManyelectionType,
            DataDeleteSelectionType
        > : IService
        where DataItemType : IDataItem
        where DataIdentifierType : IDataIdentifier
        where DataGetManyelectionType : IDataSelection
        where DataDeleteSelectionType : IDataSelection
    {
        Task<DataIdentifierType> Create(DataItemType entity);

        Task<DataItemType> Read<T>(DataIdentifierType identifier);

        Task<IEnumerable<DataItemType>> ReadMany<T>(DataGetManyelectionType query);

        Task<DataItemType> Update(DataItemType entity);

        Task Delete<T>(DataDeleteSelectionType query);

        void Configure<T>(IDataItemConfiguration configuration) where T : IDataItem;
    }
}
