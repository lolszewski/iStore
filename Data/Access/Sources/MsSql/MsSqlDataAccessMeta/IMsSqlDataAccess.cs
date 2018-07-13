using iStore.Data.Access.DataAccessCommon;
using iStore.Data.Access.DataEntitiesMeta;

namespace iStore.Data.Access.Sources.MsSql.MsSqlDataAccessMeta
{
    public interface IMsSqlDataAccess<EntityType> : IDefaultDataAccess<EntityType>
        where EntityType : IDataEntity
    {
    }
}
