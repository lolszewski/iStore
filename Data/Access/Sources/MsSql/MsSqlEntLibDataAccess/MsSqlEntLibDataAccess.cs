using iStore.Data.Access.DataAccessMeta;
using iStore.Data.Access.Sources.MsSql.MsSqlDataAccessMeta;
using iStore.Data.Access.Sources.MsSql.MsSqlDataItemsMeta;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iStore.Data.Access.Sources.MsSql.MsSqlEntLibDataAccess
{
    public class MsSqlEntLibDataAccess : IMsSqlDataAccess
    {
        public IDataLocation DataLocation { set { MsSqlDataLocation = (IMsSqlDataItemLocation)value; } }

        private IMsSqlDataItemLocation MsSqlDataLocation;

        public Task<IDataIdentifier> Create(IDataItem entity)
        {
            var msSqlDataItem = (IMsSqlDataItem)entity;
            throw new System.NotImplementedException();
        }

        public Task Delete(IDataSelection query)
        {
            throw new System.NotImplementedException();
        }

        public Task<IDataItem> Read(IDataIdentifier identifier)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<IDataItem>> ReadMany(IDataSelection query)
        {
            throw new System.NotImplementedException();
        }

        public Task<IDataItem> Update(IDataItem entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
