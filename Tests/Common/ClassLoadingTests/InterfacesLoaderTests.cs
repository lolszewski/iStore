using FluentAssertions;
using iStore.Common.ClassLoading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iStore.Tests.Common.ClassLoadingTests
{
    [TestClass]
    public class InterfacesLoaderTests
    {
        [TestMethod]
        public void ShouldLoadInterface()
        {
            var interfaces = InterfacesLoader.Instance.GetAll();
            interfaces.Should().NotBeNull("InterfacesLoader returned null interfaces list");
            interfaces.Should().NotBeEmpty("InterfacesLoader returned empty interfaces list");
        }
    }

    public interface FakeInterface { }
}
