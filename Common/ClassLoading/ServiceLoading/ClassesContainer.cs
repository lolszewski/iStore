using iStore.Core.CoreCommon;
using iStore.Core.Meta;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iStore.Common.ClassLoading.ServiceLoading
{
    public class ClassesContainer : StaticInstance<ClassesContainer>, IFilterable, IContainer<Type>
    {
        Type IContainer<Type>.Data { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Filter(string filter)
        {
            Data = from clazz in Data where clazz.FullName.Contains(filter) select clazz;
        }
    }
}
