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
        public static readonly ServiceLoader Instance = new ServiceLoader();

        private AssemblyLoader AssemblyLoader = new AssemblyLoader(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase));

        private static Dictionary<string, Type> ServicesTypes;

        private static Dictionary<string, object> ServiceInstances;

        static ServiceLoader()
        {
            ServicesTypes = new Dictionary<string, Type>();
            ServiceInstances = new Dictionary<string, object>();

            foreach (var interfaceType in InterfacesLoader.Instance.GetAll())
            {
                var implementation = ClassesLoader.Instance.GetAll()
                    .Where(t => t.GetInterface(interfaceType.Name) != null)
                    .FirstOrDefault();
                
                if (implementation != null)
                {
                    var implementationInterface = implementation.GetInterface(interfaceType.Name);
                    ServicesTypes.Add(GetKey(interfaceType, implementationInterface), implementation);
                }
            }
        }

        public T GetService<T>()
        {
            var interfaceType = typeof(T);
            var key = GetKey(interfaceType, interfaceType);
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

        private static string GetGenericParametersString(Type type)
        {
            return String.Join(".", type.GetGenericArguments().Select(a => $".{a.GetType().Name}.{a.Name}"));
        }

        private static string GetKey(Type firstPartKeyType, Type genericParametersTypeKey)
        {
            return $"{firstPartKeyType.Namespace}.{firstPartKeyType.Name}.{GetGenericParametersString(genericParametersTypeKey)}";
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
