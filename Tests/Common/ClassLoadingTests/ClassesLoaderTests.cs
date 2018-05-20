using iStore.Common.ClassLoading;
using Xunit;

namespace iStore.Tests.Common.ClassLoadingTests
{
    public class ClassesLoaderTests
    {
        [Fact]
        public void ShouldLoadClasses()
        {
            var classes = ClassesLoader.Instance.GetAll();
            Assert.NotEmpty(classes);
        }
    }
}
