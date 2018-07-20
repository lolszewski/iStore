using System.Collections.Generic;
using System.Threading.Tasks;
using iStore.Common.ClassLoading;
using iStore.Data.Access.DataAccessMeta;
using iStore.Data.Access.DataIdentifiersMeta;

namespace FakeDataAccess
{
    public class FakeDataAccess : IDataAccess
    {
        public Task<IDataIdentifier> Create(IDataItem entity)
        {
            return Task.FromResult<IDataIdentifier>((ServiceLoader.Instance.GetService<ISingleValueDataIdentifier<int>>().WithValue(123)));
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
