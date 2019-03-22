namespace iStore.Core.Meta
{
    public interface IBetween<T> : IService
    {
        T From { get; set; }

        T To { get; set; }

        bool IsBetween(T value);
    }
}
