using System.Collections.Generic;

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
        EntityIdentifierType Create(EntityType entity);

        EntityType Read(EntityIdentifierType identifier);

        IEnumerable<EntityType> ReadMany(EntityReadManyDataSelectionType query);

        EntityType Update(EntityType entity);

        void Delete(EntityRemoveDataSelectionType query);
    }
}
