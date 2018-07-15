using iStore.Data.Access.DataAccessMeta;
using iStore.Data.Access.Sources.MsSql.MsSqlDataAccessMeta;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iStore.Data.Access.Sources.MsSql.MsSqlEntLibDataAccess
{
    public class MsSqlEntLibDataAccess : IMsSqlDataAccess
    {
        public Task<IDataIdentifier> Create(IDataItem entity)
        {
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
