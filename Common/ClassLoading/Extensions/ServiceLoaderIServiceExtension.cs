using iStore.Core.Meta;
using System.Collections.Generic;

namespace iStore.Common.ClassLoading.Extensions
{
    public static class ServiceLoaderIServiceExtension
    {
        /// <summary>
        /// Returns new instance of implementation of given interface type.
        /// </summary>
        /// <typeparam name="T">Interface type</typeparam>
        /// <returns>An instance of first found implementation type</returns>
        public static T NewService<T>(this IService service)
        {
            return ServiceLoader.Instance.GetService<T>(true);
        }

        public static IEnumerable<T> NewServices<T>(this IService service, int count)
        {
            return ServiceLoader.Instance.GetServices<T>(count);
        }

        /// <summary>
        /// Returns cached instance of implementation of given interface type - should be stateless because of multi threading problems.
        /// </summary>
        /// <typeparam name="T">Interface type</typeparam>
        /// <returns>Cached instance of first found implementation type</returns>
        public static T Service<T>(this IService service)
        {
            return ServiceLoader.Instance.GetService<T>(false);
        }
    }
}
