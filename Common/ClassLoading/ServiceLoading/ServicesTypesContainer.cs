using iStore.Core.CoreCommon;
using System;
using System.Collections.Concurrent;
using System.Linq;

namespace iStore.Common.ClassLoading.ServiceLoading
{
    public class ServicesTypesContainer : StaticInstance<ServicesTypesContainer>
    {
        public readonly ConcurrentDictionary<string, Type> ServicesTypes = new ConcurrentDictionary<string, Type>();

        public readonly ConcurrentDictionary<string, object> ServiceInstances = new ConcurrentDictionary<string, object>();

        public ServicesTypesContainer()
        {
            Initialize();
        }

        public void Initialize()
        {
            foreach (var interfaceType in InterfacesLoader.Instance.GetAll())
            {
                var implementation = ClassesLoader.Instance.GetAll()
                    .Where(t => t.GetInterface(interfaceType.Name) != null)
                    .FirstOrDefault();

                if (implementation != null)
                {
                    var implementationInterface = implementation.GetInterface(interfaceType.Name);
                    ServicesTypes.TryAdd(ServiceInstanceKeyProvider.Instance.GetKey(interfaceType, implementationInterface), implementation);
                }
            }
        }
    }
}
