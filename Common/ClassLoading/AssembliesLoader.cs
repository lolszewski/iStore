using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace iStore.Common.ClassLoading
{
    public class AssembliesLoader
    {
        public static AssembliesLoader Instance = new AssembliesLoader();

        private IEnumerable<Assembly> CachedAssemblies;

        public IEnumerable<Assembly> GetAll()
        {
            if (CachedAssemblies == null)
            {
                CachedAssemblies = LoadAssemblies();
            }

            return CachedAssemblies;
        }

        private IEnumerable<Assembly> LoadAssemblies()
        {
            var directory = AssemblyDirectoryLoader.Instance.GetAssemblyDirectoryPath();
            foreach (var file in Directory.GetFiles(directory, "iStore*.dll"))
            {
                var assembly = Assembly.LoadFile(file);
                yield return assembly;
            }
        }
    }
}
