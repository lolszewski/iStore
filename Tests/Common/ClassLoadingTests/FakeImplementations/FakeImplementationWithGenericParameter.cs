using iStore.Tests.Common.ClassLoadingTests.FakeInterfaces;

namespace iStore.Tests.Common.ClassLoadingTests.FakeImplementations
{
    public class FakeImplementationWithGenericParameter<T> : IFakeGenericInterfaceForGenericParameterTest<T>
    {
    }
}
