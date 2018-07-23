using iStore.Data.Access.DataAccessMeta;

namespace iStore.Data.Access.DataAccessCommonMeta
{
    public interface IEntityBasedDataSelection : IDataSelection
    {
        IDataItem DataItem { get; set; }
    }
}
