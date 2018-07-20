using iStore.Core.CoreCommon;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace iStore.Common.ClassLoading
{
    public class ServiceLoader : StaticInstance<ServiceLoader>
    {
        private readonly AssemblyLoader AssemblyLoader = new AssemblyLoader(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase));

        private static readonly ConcurrentDictionary<string, Type> ServicesTypes;

        private static readonly ConcurrentDictionary<string, object> ServiceInstances;

        public ServiceLoader() { }

        static ServiceLoader()
        {
            ServicesTypes = new ConcurrentDictionary<string, Type>();
            ServiceInstances = new ConcurrentDictionary<string, object>();

            foreach (var interfaceType in InterfacesLoader.Instance.GetAll())
            {
                var implementation = ClassesLoader.Instance.GetAll()
                    .Where(t => t.GetInterface(interfaceType.Name) != null)
                    .FirstOrDefault();

                if (implementation != null)
                {
                    var implementationInterface = implementation.GetInterface(interfaceType.Name);
                    ServicesTypes.TryAdd(GetKey(interfaceType, implementationInterface), implementation);
                }
            }
        }

        public T GetService<T>(bool newInstance = false)
        {
            var interfaceType = typeof(T);
            var key = GetKey(interfaceType, interfaceType);
            object instance;

            if (newInstance)
            {
                instance = GetNewInstance<T>(key);
            }
            else
            {
                if (!ServiceInstances.TryGetValue(key, out instance))
                {
                    instance = GetNewInstance<T>(key);
                    ServiceInstances.TryAdd(key, instance);
                }
            }

            return (T)instance;
        }

        public IEnumerable<T> GetServices<T>(int count)
        {
            var interfaceType = typeof(T);
            var key = GetKey(interfaceType, interfaceType);

            return GetNewInstances<T>(key, count);
        }

        private T GetNewInstance<T>(string typeKey)
        {
            var type = GetTypeForInstanceCreation(typeKey);
            var instance = (T)Activator.CreateInstance(type);
            return instance;
        }

        private IEnumerable<T> GetNewInstances<T>(string typeKey, int count)
        {
            var type = GetTypeForInstanceCreation(typeKey);
            for (int i = 0; i < count; i++)
            {
                yield return (T)Activator.CreateInstance(type);
            }
        }

        private Type GetTypeForInstanceCreation(string typeKey)
        {
            var implementationType = ServicesTypes[typeKey];
            var assemblyName = implementationType.Assembly.GetName();

            var assembly = AssemblyLoader.LoadFromAssemblyName(assemblyName);
            var typeString = $"{implementationType.Namespace}.{implementationType.Name}";
            var type = assembly.GetType(typeString);

            return type;
        }

        private static string GetGenericParametersString(Type type)
        {
            return String.Join(".", type.GetGenericArguments().Select(a => $".{a.GetType().Name}.{a.Name}"));
        }

        private static string GetKey(Type firstPartKeyType, Type genericParametersTypeKey)
        {
            return $"{firstPartKeyType.Namespace}.{firstPartKeyType.Name}.{GetGenericParametersString(genericParametersTypeKey)}";
        }
    }
}
