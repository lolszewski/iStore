using System.Collections.Generic;
using System.Threading.Tasks;
using iStore.Common.ClassLoading.Extensions;
using iStore.Data.Access.DataAccessMeta;
using iStore.Data.Access.DataIdentifiersMeta;
using iStore.Tests.Model.FakeModelMeta;

namespace FakeDataAccess
{
    public class FakeDataAccess : IDataAccess
    {
        public Task<IDataIdentifier> Create(IDataItem entity)
        {
            return Task.FromResult<IDataIdentifier>(this.NewService<ISingleValueDataIdentifier<int>>().WithValue(123));
        }

        public async Task Delete(IDataSelection query)
        {
            await Task.Delay(10);
        }

        public async Task<IDataItem> Read(IDataIdentifier identifier)
        {
            return await Task.FromResult(this.NewService<IFakeModel>());
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
