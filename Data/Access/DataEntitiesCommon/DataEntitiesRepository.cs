using DataEntitiesCommonMeta;
using iStore.Data.Access.DataAccessMeta;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iStore.Data.Access.DataEntitiesCommon
{
    public class DataEntitiesRepository
        <
            DataItemType,
            DataIdentifierType,
            DataGetManyelectionType,
            DataDeleteSelectionType
        > : IDataEntitiesRepository<DataItemType, DataIdentifierType, DataGetManyelectionType, DataDeleteSelectionType>
            where DataItemType : IDataItem
            where DataIdentifierType : IDataIdentifier
            where DataGetManyelectionType : IDataSelection
            where DataDeleteSelectionType : IDataSelection
    {
        private readonly ConcurrentDictionary<Type, IDataEntityConfigurationItem> Entities = new ConcurrentDictionary<Type, IDataEntityConfigurationItem>();

        public void Configure<T>(IDataEntityConfigurationItem configuration) where T : IDataItem
        {
            Entities.TryAdd(typeof(T), configuration);
        }

        public async Task<DataIdentifierType> Create(DataItemType entity)
        {
            Entities.TryGetValue(entity.GetType(), out var repo);
            return (DataIdentifierType)await repo.GetDataAccess().Create(entity);
        }

        public async Task Delete<T>(DataDeleteSelectionType query)
        {
            Entities.TryGetValue(typeof(T), out var repo);
            await repo.GetDataAccess().Delete(query);
        }

        public async Task<DataItemType> Read<T>(DataIdentifierType identifier)
        {
            Entities.TryGetValue(typeof(T), out var repo);
            return (DataItemType)await repo.GetDataAccess().Read(identifier);
        }

        public async Task<IEnumerable<DataItemType>> ReadMany<T>(DataGetManyelectionType query)
        {
            Entities.TryGetValue(typeof(T), out var repo);
            return (IEnumerable<DataItemType>)await repo.GetDataAccess().ReadMany(query);
        }

        public async Task<DataItemType> Update(DataItemType entity)
        {
            Entities.TryGetValue(entity.GetType(), out var repo);
            return (DataItemType)await repo.GetDataAccess().Update(entity);
        }
    }
}
