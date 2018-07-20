using iStore.Constants.Namespace.IStoreLibrariesNames;
using iStore.Core.CoreCommon;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace iStore.Common.ClassLoading
{
    public class AssembliesLoader : StaticInstance<AssembliesLoader>
    {
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
