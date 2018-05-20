using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace iStore.Common.ClassLoading
{
    public class InterfacesLoader
    {
        public static InterfacesLoader Instance = new InterfacesLoader();

        private IEnumerable<Type> CachedInterfaces;

        public IEnumerable<Type> GetAll()
        {
            if (CachedInterfaces == null)
            {
                CachedInterfaces =  AssembliesLoader.Instance.GetAll()
                    .Select(a => a.GetTypes().Where(t => t.IsInterface))
                    .Aggregate((first, second) => first.Concat(second));
            }

            return CachedInterfaces;
        }
    }
}
