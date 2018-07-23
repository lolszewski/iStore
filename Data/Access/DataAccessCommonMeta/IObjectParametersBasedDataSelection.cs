using iStore.Data.Access.DataAccessMeta;

namespace iStore.Data.Access.DataAccessCommonMeta
{
    public interface IObjectParametersBasedDataSelection : IDataSelection
    {
        object[] Parameters { get; set; }
    }
}
