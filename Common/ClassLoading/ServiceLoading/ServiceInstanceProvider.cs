using iStore.Core.CoreCommon;
using System;
using System.Collections.Generic;

namespace iStore.Common.ClassLoading.ServiceLoading
{
    public class ServiceInstanceProvider : StaticInstance<ServiceInstanceProvider>
    {
        public T GetNewInstance<T>(string typeKey)
        {
            var type = ServiceInstanceTypeProvider.Instance.GetTypeForInstanceCreation(typeKey);
            var instance = (T)Activator.CreateInstance(type);
            return instance;
        }

        public IEnumerable<T> GetNewInstances<T>(string typeKey, int count)
        {
            var type = ServiceInstanceTypeProvider.Instance.GetTypeForInstanceCreation(typeKey);
            for (int i = 0; i < count; i++)
            {
                yield return (T)Activator.CreateInstance(type);
            }
        }
    }
}
