using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace iStore.Common.ClassLoading
{
    public class ServiceLoader
    {
        public static ServiceLoader Instance = new ServiceLoader();

        private AssemblyLoader AssemblyLoader = new AssemblyLoader(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase));

        private static Dictionary<string, Type> ServicesTypes;

        private static Dictionary<string, object> ServiceInstances;

        static ServiceLoader()
        {
            ServicesTypes = new Dictionary<string, Type>();
            ServiceInstances = new Dictionary<string, object>();

            foreach (var interfaceType in InterfacesLoader.Instance.GetAll())
            {
                var implementation = ClassesLoader.Instance.GetAll().Where(t => interfaceType.IsAssignableFrom(t)).FirstOrDefault();
                if (implementation != null)
                {
                    ServicesTypes.Add($"{interfaceType.Namespace}.{interfaceType.Name}", implementation);
                }
            }
        }

        public T GetService<T>()
        {
            var interfaceType = typeof(T);
            var key = $"{interfaceType.Namespace}.{interfaceType.Name}";
            lock (ServiceInstances)
            {
                if (!ServiceInstances.ContainsKey(key))
                {
                    var implementationType = ServicesTypes[key];
                    var assemblyName = implementationType.Assembly.GetName();

                    var assembly = AssemblyLoader.LoadFromAssemblyName(assemblyName);
                    var typeString = $"{implementationType.Namespace}.{implementationType.Name}";
                    var type = assembly.GetType(typeString);

                    T instance = (T)Activator.CreateInstance(type);
                    ServiceInstances.Add(key, instance);
                }

                return (T)ServiceInstances[key];
            }
        }

        class ServiceProvider : IServiceProvider
        {
            public object GetService(Type serviceType)
            {
                throw new NotImplementedException();
            }
        }
    }
}
