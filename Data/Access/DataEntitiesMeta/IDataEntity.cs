using System.Collections.Generic;

namespace iStore.Data.Access.DataEntitiesMeta
{
    public interface IDataEntity
    {
        IDictionary<string, object> GetConfiguration();
    }
}
