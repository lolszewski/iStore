using iStore.Data.Access.DataAccessCommonMeta;

namespace iStore.Data.Access.DataAccessCommon
{
    public class ObjectParametersBasedDataSelection : IObjectParametersBasedDataSelection
    {
        public object[] Parameters { get; set; }
    }
}
