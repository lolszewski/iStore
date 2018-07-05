using System;
using System.IO;
using System.Reflection;

namespace iStore.Common.ClassLoading
{
    public class AssemblyDirectoryLoader
    {
        public static readonly AssemblyDirectoryLoader Instance = new AssemblyDirectoryLoader();

        private static string CachedDirectoryPath;

        static AssemblyDirectoryLoader()
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            CachedDirectoryPath = Path.GetDirectoryName(path);
        }

        public string GetAssemblyDirectoryPath()
        {
            return CachedDirectoryPath;
        }
    }
}
