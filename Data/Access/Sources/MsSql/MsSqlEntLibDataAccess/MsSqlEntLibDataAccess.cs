using iStore.Data.Access.DataEntitiesMeta;
using iStore.Data.Access.Sources.MsSql.MsSqlDataAccessMeta;
using System.Collections.Generic;

namespace iStore.Data.Access.Sources.MsSql.MsSqlEntLibDataAccess
{
    public class MsSqlEntLibDataAccess<EntityType> : IMsSqlDataAccess<EntityType>
        where EntityType : IDataEntity
    {
        public string Create(EntityType entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(object[] query)
        {
            throw new System.NotImplementedException();
        }

        public EntityType Read(string identifier)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<EntityType> ReadMany(object[] query)
        {
            throw new System.NotImplementedException();
        }

        public EntityType Update(EntityType entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
