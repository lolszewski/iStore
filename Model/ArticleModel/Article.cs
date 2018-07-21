using iStore.Data.Access.DataIdentifiersMeta;
using iStore.Model.ArticleModelMeta;

namespace iStore.Model.ArticleModel
{
    public class Article : IArticle
    {
        public IIntValueDataIdentifier Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public Article(IIntValueDataIdentifier id, string name, string code)
        {
            Id = id;
            Name = name;
            Code = code;
        }
    }
}
