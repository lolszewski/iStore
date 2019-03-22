using iStore.Core.Meta;
using iStore.Data.Access.DataAccessMeta;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iStore.Data.Access.DataItemsCommonMeta
{
    public interface IDataItemRepository : IService
    {
        IDataAccess DataAccess { get; set; }

        IDataLocation DataLocation { get; set; }

        Task<T> Create<T>(IDataItem entity) where T : IDataIdentifier;

        Task<T> Read<T>(IDataIdentifier identifier) where T : IDataItem;

        Task<IEnumerable<T>> ReadMany<T>(IDataSelection query) where T : IDataItem;

        Task<T> Update<T>(T entity) where T : IDataItem;

        Task Delete<T>(IDataSelection query);
    }
}
