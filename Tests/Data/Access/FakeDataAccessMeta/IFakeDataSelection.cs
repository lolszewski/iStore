using iStore.Data.Access.DataAccessMeta;

namespace iStore.Tests.Data.Access.FakeDataAccessMeta
{
    public interface IFakeDataSelection : IDataSelection
    {
        object[] Parameters { get; set; }
    }
}
