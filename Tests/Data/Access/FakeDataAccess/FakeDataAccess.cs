using System.Collections.Generic;
using System.Threading.Tasks;
using iStore.Common.ClassLoading.Extensions;
using iStore.Data.Access.DataAccessMeta;
using iStore.Data.Access.DataIdentifiersMeta;
using iStore.Tests.Data.Access.FakeDataAccessMeta;
using iStore.Tests.Model.FakeModelMeta;

namespace iStore.Tests.Data.Access.FakeDataAccess
{
    public class FakeDataAccess : IFakeDataAccess
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

        public async Task<IEnumerable<IDataItem>> ReadMany(IDataSelection query)
        {
            return await Task.FromResult(this.NewServices<IFakeModel>(10));
        }

        public async Task<IDataItem> Update(IDataItem entity)
        {
            return await Task.FromResult(this.NewService<IFakeModel>());
        }
    }
}
