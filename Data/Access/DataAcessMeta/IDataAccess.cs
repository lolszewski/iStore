using iStore.Core.Meta;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iStore.Data.Access.DataAccessMeta
{
    public interface IDataAccess : IService
    {
        Task<IDataIdentifier> Create(IDataItem entity);

        Task<IDataItem> Read(IDataIdentifier identifier);

        Task<IEnumerable<IDataItem>> ReadMany(IDataSelection query);

        Task<IDataItem> Update(IDataItem entity);

        Task Delete(IDataSelection query);
    }
}
