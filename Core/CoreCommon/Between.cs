using iStore.Core.Meta;
using System;

namespace iStore.Core.CoreCommon
{
    public abstract class Between<T> : IBetween<T>
    {
        public T From { get; set; }

        public T To { get; set; }

        public abstract bool IsBetween(T value);
    }
}
