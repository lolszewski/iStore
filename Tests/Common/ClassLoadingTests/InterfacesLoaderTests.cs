using iStore.Common.ClassLoading;
using Xunit;

namespace iStore.Tests.Common.ClassLoadingTests
{
    public class InterfacesLoaderTests
    {
        [Fact]
        public void ShouldLoadInterface()
        {
            var interfaces = InterfacesLoader.Instance.GetAll();
            Assert.NotEmpty(interfaces);
        }
    }

    public interface FakeInterface { }
}
