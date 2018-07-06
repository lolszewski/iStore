using iStore.Common.ClassLoading;
using iStore.Data.Access.DataSources.MsSql.MsSqlDataSourceMeta;
using iStore.Data.DataModel.ArticlesDataModel;
using iStore.Data.DataModel.DataModelMeta;

namespace iStore.Data.DataModel.MsSql.ArticlesDataModel
{
    public class ArticlesDataModel : IArticleDataModel
    {
        public IDataSelection GetDataSelection()
        {
            throw new System.NotImplementedException();
        }

        public IDataSource GetDataSource()
        {
            return ServiceLoader.Instance.GetService<IMsSqlDataSource>(true);
        }
    }
}
