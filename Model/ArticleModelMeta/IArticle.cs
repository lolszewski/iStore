using iStore.Data.Access.DataAccessMeta;
using iStore.Data.Access.DataIdentifiersMeta;

namespace iStore.Model.ArticleModelMeta
{
    public interface IArticle : IDataItem
    {
        IIntValueDataIdentifier Id { get; set; }

        string Name { get; set; }

        string Code { get; set; }
    }
}
