using iStore.Data.Access.DataEntitiesMeta;
using iStore.Data.Access.Sources.MsSql.MsSqlDataAccessMeta;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iStore.Data.Access.Sources.MsSql.MsSqlEntLibDataAccess
{
    public class MsSqlEntLibDataAccess<EntityType> : IMsSqlDataAccess<EntityType>
        where EntityType : IDataEntity
    {
        public async Task<string> Create(EntityType entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task Delete(object[] query)
        {
            throw new System.NotImplementedException();
        }

        public async Task<EntityType> Read(string identifier)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<EntityType>> ReadMany(object[] query)
        {
            throw new System.NotImplementedException();
        }

        public async Task<EntityType> Update(EntityType entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
