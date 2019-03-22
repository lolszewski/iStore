using iStore.Common.ClassLoading.ServiceLoading;
using iStore.Core.CoreCommon;
using iStore.Core.Meta;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iStore.Common.ClassLoading
{
    public class ClassesLoader : StaticInstance<ClassesLoader>
    {
        static ClassesLoader()
        {
            ClassesContainer.Instance.Data = AssembliesLoader.Instance.GetAll()
                .Select(a => a.GetTypes().Where(t => !t.IsInterface))
                .Aggregate((first, second) => first.Concat(second));
        }

        public IEnumerable<Type> GetAll()
        {
            return ClassesContainer.Instance.Data;
        }
    }
}
