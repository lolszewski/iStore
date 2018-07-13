using iStore.Data.Access.DataAcessMeta;
using iStore.Data.Access.DataEntitiesMeta;

namespace iStore.Data.Access.DataAccessCommon
{
    public interface IDefaultDataAccess<EntityType> : IDataAccess<EntityType, string, object[], object[]>
        where EntityType: IDataEntity
    {
    }
}
