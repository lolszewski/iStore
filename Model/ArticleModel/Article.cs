using iStore.Data.Access.DataAccessMeta;

namespace iStore.Model.ArticleModel
{
    public class Article : IDataItem
    {
        public int Id { get; set; } = -1;

        public string Name { get; set; } = string.Empty;

        public string Code { get; set; } = string.Empty;
    }
}
