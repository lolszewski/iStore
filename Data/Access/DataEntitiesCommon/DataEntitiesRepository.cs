using DataEntitiesCommonMeta;
using iStore.Data.Access.DataAccessMeta;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iStore.Data.Access.DataEntitiesCommon
{
    public class DataEntitiesRepository : IDataEntitiesRepository
    {
        private readonly ConcurrentDictionary<Type, IDataEntityConfigurationItem> Entities = new ConcurrentDictionary<Type, IDataEntityConfigurationItem>();
        
        public Task<IDataIdentifier> Create(IDataItem entity)
        {
            Entities.TryGetValue(entity.GetType(), out var repo);
            return repo.GetDataAccess().Create(entity);
        }

        public Task<IDataItem> Read<T>(IDataIdentifier identifier)
        {
            Entities.TryGetValue(typeof(T), out var repo);
            return repo.GetDataAccess().Read(identifier);
        }

        public Task<IEnumerable<IDataItem>> ReadMany<T>(IDataSelection query)
        {
            Entities.TryGetValue(typeof(T), out var repo);
            return repo.GetDataAccess().ReadMany(query);
        }

        public Task<IDataItem> Update(IDataItem entity)
        {
            Entities.TryGetValue(entity.GetType(), out var repo);
            return repo.GetDataAccess().Update(entity);
        }

        public Task Delete<T>(IDataSelection query)
        {
            Entities.TryGetValue(typeof(T), out var repo);
            return repo.GetDataAccess().Delete(query);
        }

        public void Configure<T>(IDataEntityConfigurationItem configuration) where T : IDataItem
        {
            Entities.TryAdd(typeof(T), configuration);
        }
    }
}
