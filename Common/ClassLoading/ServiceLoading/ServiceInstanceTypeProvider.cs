using iStore.Core.CoreCommon;
using System;
using System.IO;
using System.Reflection;

namespace iStore.Common.ClassLoading.ServiceLoading
{
    public class ServiceInstanceTypeProvider : StaticInstance<ServiceInstanceTypeProvider>
    {
        private readonly AssemblyLoader AssemblyLoader = new AssemblyLoader(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase));

        public Type GetTypeForInstanceCreation(string typeKey)
        {
            var implementationType = ServicesTypesContainer.Instance.ServicesTypes[typeKey];
            var assemblyName = implementationType.Assembly.GetName();

            var assembly = AssemblyLoader.LoadFromAssemblyName(assemblyName);
            var typeString = $"{implementationType.Namespace}.{implementationType.Name}";
            var type = assembly.GetType(typeString);

            return type;
        }
    }
}
