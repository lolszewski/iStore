using iStore.Core.Meta;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iStore.Data.Access.DataAccessMeta
{
    public interface IDataAccess : IService
    {
        IDataLocation DataLocation { set; }

        Task<IDataIdentifier> Create(IDataItem entity);

        Task<IDataItem> Read(IDataIdentifier identifier);

        Task<IEnumerable<IDataItem>> ReadMany(IDataSelection query);

        Task<IDataItem> Update(IDataItem entity);

        Task Delete(IDataSelection query);
    }

    public interface IDataAccess<DataLocationType, DataIdentifierType, DataItemType, DataSelectionType> : IService
    {
        DataLocationType DataLocation { get; set; }

        Task<DataIdentifierType> Create(DataItemType entity);

        Task<IEnumerable<DataItemType>> Read(DataSelectionType query);

        Task<int> Update(DataSelectionType query, DataItemType entity);

        Task<int> Delete(DataSelectionType query);
    }
}
