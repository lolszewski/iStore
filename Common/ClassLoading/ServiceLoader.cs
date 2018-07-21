using iStore.Common.ClassLoading.ServiceLoading;
using iStore.Core.CoreCommon;
using System.Collections.Generic;

namespace iStore.Common.ClassLoading
{
    public class ServiceLoader : StaticInstance<ServiceLoader>
    {
        public T GetService<T>(bool newInstance = false)
        {
            var key = ServiceInstanceKeyProvider.Instance.GetKey<T>();
            object instance;

            if (newInstance)
            {
                instance = ServiceInstanceProvider.Instance.GetNewInstance<T>(key);
            }
            else
            {
                if (!ServicesTypesContainer.Instance.ServiceInstances.TryGetValue(key, out instance))
                {
                    instance = ServiceInstanceProvider.Instance.GetNewInstance<T>(key);
                    ServicesTypesContainer.Instance.ServiceInstances.TryAdd(key, instance);
                }
            }

            return (T)instance;
        }

        public IEnumerable<T> GetServices<T>(int count)
        {
            var key = ServiceInstanceKeyProvider.Instance.GetKey<T>();

            return ServiceInstanceProvider.Instance.GetNewInstances<T>(key, count);
        }

        public T GetServiceWithValues<T>(params object[] values)
        {
            var key = ServiceInstanceKeyProvider.Instance.GetKey<T>();

            return ServiceInstanceProvider.Instance.GetNewInstanceWithValues<T>(key, values);
        }
    }
}
