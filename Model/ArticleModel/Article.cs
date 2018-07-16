using iStore.Common.ClassLoading;
using iStore.Data.Access.DataAccessMeta;
using iStore.Data.Access.DataIdentifiersMeta;

namespace iStore.Model.ArticleModel
{
    public class Article : IDataItem
    {
        public IIntValueDataIdentifier Id { get; set; } = ServiceLoader.Instance.GetService<IIntValueDataIdentifier>();

        public string Name { get; set; } = string.Empty;

        public string Code { get; set; } = string.Empty;
    }
}
