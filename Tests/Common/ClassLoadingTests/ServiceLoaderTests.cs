using FluentAssertions;
using iStore.Common.ClassLoading;
using iStore.Tests.Common.ClassLoadingTests.FakeInterfaces;
using iStore.Tests.Common.ClassLoadingTests.FakeObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iStore.Tests.Common.ClassLoadingTests
{
    [TestClass]
    public class ServiceLoaderTests
    {
        [TestMethod]
        public void ShouldLoadNonGenericServiceImplementation()
        {
            var fakeNonGenericInterfaceImplementation = ServiceLoader.Instance.GetService<IFakeNonGenericInterface>();
            fakeNonGenericInterfaceImplementation.Should().NotBeNull("there is an active implementation of desired interface so it should be loaded");
            fakeNonGenericInterfaceImplementation.FakeMethod().Should().NotBeNull("implemented method returns not null string");
            fakeNonGenericInterfaceImplementation.FakeMethod().Should().NotBeEmpty("implemented method returns not empty string");
        }

        [TestMethod]
        public void ShouldLoadGenericServiceImplementation()
        {
            var fakeGenericInterfaceImplementation = ServiceLoader.Instance.GetService<IFakeGenericInterface<FakeGenericParameter>>();
            fakeGenericInterfaceImplementation.Should().NotBeNull("there is an active implementation of desired interface with generic parameter so it should be loaded");
        }

        [TestMethod]
        public void ShouldLoadGenericServiceImplementationWithTwoParameters()
        {
            var fakeGenericInterfaceImplementationWithTwoParameters = ServiceLoader.Instance.GetService<IFakeGenericInterfaceWithTwoParameters<FakeGenericParameter, FakeGenericParameter>>();
            fakeGenericInterfaceImplementationWithTwoParameters.Should().NotBeNull("there is an active implementation of desired interface with generic parameter so it should be loaded");
        }
    }
}
