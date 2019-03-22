using iStore.Core.CoreCommon;
using iStore.Core.Meta;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iStore.Common.ClassLoading
{
    public class InterfacesLoader : StaticInstance<InterfacesLoader>, IFilterable
    {
        private static IEnumerable<Type> CachedInterfaces;

        static InterfacesLoader()
        {
            CachedInterfaces = AssembliesLoader.Instance.GetAll()
                .Select(a => a.GetTypes().Where(t => t.IsInterface))
                .Aggregate((first, second) => first.Concat(second));
        }

        public IEnumerable<Type> GetAll()
        {
            return CachedInterfaces;
        }

        public void Filter(string filter)
        {
            CachedInterfaces = CachedInterfaces.Where(t => t.FullName.Contains(filter));
        }
    }
}
