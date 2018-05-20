using System;
using System.IO;
using System.Reflection;

namespace iStore.Common.ClassLoading
{
    public class AssemblyDirectoryLoader
    {
        public static AssemblyDirectoryLoader Instance = new AssemblyDirectoryLoader();

        private string CachedDirectoryPath;

        public string GetAssemblyDirectoryPath()
        {
            if (CachedDirectoryPath == null)
            {
                var codeBase = Assembly.GetExecutingAssembly().CodeBase;
                var uri = new UriBuilder(codeBase);
                var path = Uri.UnescapeDataString(uri.Path);
                CachedDirectoryPath = Path.GetDirectoryName(path);
            }

            return CachedDirectoryPath;
        }
    }
}
