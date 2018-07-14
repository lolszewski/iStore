using System.Collections.Generic;
using System.Threading.Tasks;

namespace iStore.Data.Access.DataAcessMeta
{
    public interface IDataAccess
        <
            EntityType,
            EntityIdentifierType,
            EntityReadManyDataSelectionType, 
            EntityRemoveDataSelectionType
        >
    {
        Task<EntityIdentifierType> Create(EntityType entity);

        Task<EntityType> Read(EntityIdentifierType identifier);

        Task<IEnumerable<EntityType>> ReadMany(EntityReadManyDataSelectionType query);

        Task<EntityType> Update(EntityType entity);

        Task Delete(EntityRemoveDataSelectionType query);
    }
}
