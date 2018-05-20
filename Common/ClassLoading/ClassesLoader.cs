
using System;
using System.Collections.Generic;
using System.Linq;

namespace iStore.Common.ClassLoading
{
    public class ClassesLoader
    {
        public static ClassesLoader Instance = new ClassesLoader();

        private IEnumerable<Type> CachedClasses;

        public IEnumerable<Type> GetAll()
        {
            if (CachedClasses == null)
            {
                CachedClasses = AssembliesLoader.Instance.GetAll()
                    .Select(a => a.GetTypes().Where(t => !t.IsInterface))
                    .Aggregate((first, second) => first.Concat(second));
            }

            return CachedClasses;
        }
    }
}
