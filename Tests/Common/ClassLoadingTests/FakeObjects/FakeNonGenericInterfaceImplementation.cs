using System;
using System.Collections.Generic;
using System.Text;

namespace iStore.Tests.Common.ClassLoadingTests.FakeObjects
{
    public class FakeNonGenericInterfaceImplementation : FakeNonGenericInterface
    {
        public string FakeMethod()
        {
            return "123";
        }
    }
}
