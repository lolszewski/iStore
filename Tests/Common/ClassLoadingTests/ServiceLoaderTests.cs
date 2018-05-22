using iStore.Common.ClassLoading;
using iStore.Tests.Common.ClassLoadingTests.FakeObjects;
using Xunit;

namespace iStore.Tests.Common.ClassLoadingTests
{
    public class ServiceLoaderTests
    {
        [Fact]
        public void ShouldLoadServiceImplementation()
        {
            var implementation = ServiceLoader.Instance.GetService<FakeNonGenericInterface>();
            Assert.NotNull(implementation);
            Assert.Equal("123", implementation.FakeMethod());
        }

        [Fact]
        public void ShouldLoadServiceImplementation2()
        {
            var implementation = ServiceLoader.Instance.GetService<FakeNonGenericInterface>();
            Assert.NotNull(implementation);
            Assert.Equal("123", implementation.FakeMethod());
        }
    }
}
