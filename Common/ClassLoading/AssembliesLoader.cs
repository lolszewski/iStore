using iStore.Constants.Namespace.IStoreLibrariesNames;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace iStore.Common.ClassLoading
{
    public class AssembliesLoader
    {
        public static readonly AssembliesLoader Instance = new AssembliesLoader();

        private static IEnumerable<Assembly> CachedAssemblies;

        static AssembliesLoader()
        {
            CachedAssemblies = LoadAssemblies();
        }

        public IEnumerable<Assembly> GetAll()
        {
            return CachedAssemblies;
        }

        private static IEnumerable<Assembly> LoadAssemblies()
        {
            var directory = AssemblyDirectoryLoader.Instance.GetAssemblyDirectoryPath();
            foreach (var file in Directory.GetFiles(directory, iStoreLibrariesDependencyInjectionSearchpattern.Pattern))
            {
                var assembly = Assembly.LoadFile(file);
                yield return assembly;
            }
        }
    }
}
