using iStore.Tests.Common.ClassLoadingTests.FakeInterfaces;
using System;

namespace iStore.Tests.Common.ClassLoadingTests.FakeImplementations
{
    public class FakeInterfaceWithStringMethodImplementation : IFakeInterfaceWithStringMethod
    {
        public string Id = Guid.NewGuid().ToString();

        public string GetValue()
        {
            return Id;
        }
    }
}
