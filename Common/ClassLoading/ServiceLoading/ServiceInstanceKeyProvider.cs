using iStore.Core.CoreCommon;
using System;
using System.Linq;

namespace iStore.Common.ClassLoading.ServiceLoading
{
    internal class ServiceInstanceKeyProvider : StaticInstance<ServiceInstanceKeyProvider>
    {
        internal string GetGenericParametersString(Type type)
        {
            return String.Join(".", type.GetGenericArguments().Select(a => $".{a.GetType().Name}.{a.Name}"));
        }

        internal string GetKey(Type firstPartKeyType, Type genericParametersTypeKey)
        {
            return $"{firstPartKeyType.Namespace}.{firstPartKeyType.Name}.{GetGenericParametersString(genericParametersTypeKey)}";
        }
    }
}
