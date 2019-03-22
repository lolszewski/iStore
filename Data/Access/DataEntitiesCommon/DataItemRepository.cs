using iStore.Data.Access.DataAccessMeta;
using iStore.Data.Access.DataItemsCommonMeta;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iStore.Data.Access.DataItemsCommon
{
    public class DataItemRepository : IDataItemRepository
    {
        private readonly ConcurrentDictionary<Type, IDataItemConfiguration> Entities = new ConcurrentDictionary<Type, IDataItemConfiguration>();

        public IDataAccess DataAccess { get; set; }

        public IDataLocation DataLocation { get; set; }

        public async Task<T> Create<T>(IDataItem entity) where T : IDataIdentifier
        {
            return (T)await DataAccess.Create(entity);
        }

        public async Task Delete<T>(IDataSelection query)
        {
            await DataAccess.Delete(query);
        }

        public async Task<T> Read<T>(IDataIdentifier identifier) where T : IDataItem
        {
            return (T)await DataAccess.Read(identifier);
        }

        public async Task<IEnumerable<T>> ReadMany<T>(IDataSelection query) where T : IDataItem
        {
            return (IEnumerable<T>)await DataAccess.ReadMany(query);
        }

        public async Task<T> Update<T>(T entity) where T : IDataItem
        {
            return (T)await DataAccess.Update(entity);
        }
    }
}
