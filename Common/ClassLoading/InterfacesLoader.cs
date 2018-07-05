using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace iStore.Common.ClassLoading
{
    public class InterfacesLoader
    {
        public static readonly InterfacesLoader Instance = new InterfacesLoader();

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
    }
}
