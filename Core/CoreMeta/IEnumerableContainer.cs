using System.Collections.Generic;

namespace iStore.Core.Meta
{
    public interface IEnumerableContainer<T> : IService
    {
        IEnumerable<T> Data { get; set; }
    }
}
