using FluentAssertions;
using iStore.Common.ClassLoading;
using iStore.Tests.Common.ClassLoadingTests.FakeInterfaces;
using iStore.Tests.Common.ClassLoadingTests.FakeObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
        public void ShouldLoadNonGenericServiceImplementationSameInstance()
        {
            var firstImplementation = ServiceLoader.Instance.GetService<IFakeInterfaceWithStringMethod>();
            var secondImplementation = ServiceLoader.Instance.GetService<IFakeInterfaceWithStringMethod>();
            firstImplementation.GetValue().Should().Equals(secondImplementation.GetValue());
        }

        [TestMethod]
        public void ShouldLoadNonGenericServiceImplementationNewInstance()
        {
            var firstImplementation = ServiceLoader.Instance.GetService<IFakeInterfaceWithStringMethod>(true);
            var secondImplementation = ServiceLoader.Instance.GetService<IFakeInterfaceWithStringMethod>(true);
            firstImplementation.GetValue().Should().NotBe(secondImplementation.GetValue());
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

        [TestMethod]
        public void ShouldLoadServicesImplementationWithNestedInterfaces()
        {
            var fakeNestedInterfaceLevel3 = ServiceLoader.Instance.GetService<IFakeNestedInterfaceLevel3>();
            fakeNestedInterfaceLevel3.Should().NotBeNull("there is an active implementation of desired interface with generic parameter so it should be loaded");
            var fakeNestedInterfaceLevel1 = ServiceLoader.Instance.GetService<IFakeNestedInterfaceLevel1>();
            fakeNestedInterfaceLevel1.Should().NotBeNull("there is an active implementation of desired interface with generic parameter so it should be loaded");
            var fakeNestedInterfaceLevel2 = ServiceLoader.Instance.GetService<IFakeNestedInterfaceLevel2>();
            fakeNestedInterfaceLevel2.Should().NotBeNull("there is an active implementation of desired interface with generic parameter so it should be loaded");
        }

        [TestMethod]
        public void ShouldLoadServicesImplementationWithValues()
        {
            var fakeNestedInterfaceLevel3 = ServiceLoader.Instance.GetServiceWithValues<IFakeModel>(123, "value", new List<string>() { "value1", "value2" });
            fakeNestedInterfaceLevel3.IntField.Should().NotBe(default(int));
            fakeNestedInterfaceLevel3.StringField.Should().NotBe(default(string));
            fakeNestedInterfaceLevel3.StringsList.Should().HaveCountGreaterThan(default(int));
        }
    }
}
