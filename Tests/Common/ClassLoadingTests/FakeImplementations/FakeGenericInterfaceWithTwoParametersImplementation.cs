﻿using iStore.Tests.Common.ClassLoadingTests.FakeInterfaces;
using iStore.Tests.Common.ClassLoadingTests.FakeObjects;

namespace iStore.Tests.Common.ClassLoadingTests.FakeImplementations
{
    public class FakeGenericInterfaceWithTwoParametersImplementation : IFakeGenericInterfaceWithTwoParameters<FakeGenericParameter, FakeGenericParameter>
    {
    }
}
