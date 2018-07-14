using System.Collections.Generic;
using System.Threading.Tasks;

namespace iStore.Data.Access.DataEntitiesMeta
{
    public interface IDataEntity
    {
        Task<IDictionary<string, object>> GetConfiguration();
    }
}
