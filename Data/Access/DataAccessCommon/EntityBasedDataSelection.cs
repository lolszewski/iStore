using iStore.Data.Access.DataAccessCommonMeta;
using iStore.Data.Access.DataAccessMeta;

namespace iStore.Data.Access.DataAccessCommon
{
    public class EntityBasedDataSelection : IEntityBasedDataSelection
    {
        public IDataItem DataItem { get; set; }
    }
}
