using iStore.Tests.Data.Access.FakeDataAccessMeta;

namespace iStore.Tests.Data.Access.FakeDataAccess
{
    public class FakeDataSelection : IFakeDataSelection
    {
        public object[] Parameters { get; set; }
    }
}
