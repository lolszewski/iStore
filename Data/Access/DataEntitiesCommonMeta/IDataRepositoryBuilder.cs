using iStore.Core.Meta;

namespace iStore.Data.Access.DataItemsCommonMeta
{
    public interface IDataRepositoryBuilder : IService
    {
        IDataItemRepository Build();
    }
}
