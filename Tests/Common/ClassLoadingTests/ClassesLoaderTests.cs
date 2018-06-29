using FluentAssertions;
using iStore.Common.ClassLoading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iStore.Tests.Common.ClassLoadingTests
{
    [TestClass]
    public class ClassesLoaderTests
    {
        [TestMethod]
        public void ShouldLoadClasses()
        {
            var classes = ClassesLoader.Instance.GetAll();
            classes.Should().NotBeNull("Classes loader returned null classes list");
            classes.Should().NotBeEmpty("Classes loader returned empty classes list");
        }
    }
}
