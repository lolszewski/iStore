﻿using iStore.Common.ClassLoading;
using iStore.Data.Access.DataEntitiesCommon;
using iStore.Model.ArticleModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iStore.Tests.Model.ArticleModelTests
{
    [TestClass]
    public class ArticlesEntityRepositoryTests
    {
        [TestMethod]
        public void TestRepositoryLoading()
        {
            var service = ServiceLoader.Instance.GetService<IDataEntitiesRepository>();
            service.Configure<Article>(null);
        }
    }
}