using iStore.Tests.Common.ClassLoadingTests.FakeInterfaces;

namespace iStore.Tests.Common.ClassLoadingTests.FakeImplementations
{
    public class FakeNonGenericInterfaceImplementation : IFakeNonGenericInterface
    {
        public string FakeMethod()
        {
            return "123";
        }
    }
}
