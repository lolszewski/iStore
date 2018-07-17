﻿using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Reflection;

namespace iStore.Common.ClassLoading
{
    public class ServiceLoader
    {
        public static readonly ServiceLoader Instance = new ServiceLoader();

        private readonly AssemblyLoader AssemblyLoader = new AssemblyLoader(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase));

        private static readonly ConcurrentDictionary<string, Type> ServicesTypes;

        private static readonly ConcurrentDictionary<string, object> ServiceInstances;

        private ServiceLoader() { }

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
