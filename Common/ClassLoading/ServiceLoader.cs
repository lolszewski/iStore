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

        private readonly AssemblyLoader AssemblyLoader = new AssemblyLoader(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase));

        private static readonly IDictionary<string, Type> ServicesTypes;

        private static readonly IDictionary<string, object> ServiceInstances;

        private ServiceLoader() { }

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

        public T GetService<T>(bool newInstance = false)
        {
            var interfaceType = typeof(T);
            var key = GetKey(interfaceType, interfaceType);
            T instance;

            if (newInstance)
            {
                instance = GetNewInstance<T>(key);
            }
            else
            {
                lock (ServiceInstances)
                {
                    if (!ServiceInstances.ContainsKey(key))
                    {
                        instance = GetNewInstance<T>(key);
                        ServiceInstances.Add(key, instance);
                    }
                    else
                    {
                        instance = (T)ServiceInstances[key];
                    }
                }
            }

            return instance;
        }

        private T GetNewInstance<T>(string typeKey)
        {
            var implementationType = ServicesTypes[typeKey];
            var assemblyName = implementationType.Assembly.GetName();

            var assembly = AssemblyLoader.LoadFromAssemblyName(assemblyName);
            var typeString = $"{implementationType.Namespace}.{implementationType.Name}";
            var type = assembly.GetType(typeString);

            var instance = (T)Activator.CreateInstance(type);
            return instance;
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
