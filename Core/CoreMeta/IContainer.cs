namespace iStore.Core.Meta
{
    public interface IContainer<T> : IService
    {
        T Data { get; set; }
    }
}
