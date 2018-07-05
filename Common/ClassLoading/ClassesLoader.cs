
using System;
using System.Collections.Generic;
using System.Linq;

namespace iStore.Common.ClassLoading
{
    public class ClassesLoader
    {
        public static readonly ClassesLoader Instance = new ClassesLoader();

        private static IEnumerable<Type> CachedClasses;
        static ClassesLoader()
        {
            CachedClasses = AssembliesLoader.Instance.GetAll()
                .Select(a => a.GetTypes().Where(t => !t.IsInterface))
                .Aggregate((first, second) => first.Concat(second));
        }

        public IEnumerable<Type> GetAll()
        {
            return CachedClasses;
        }
    }
}
