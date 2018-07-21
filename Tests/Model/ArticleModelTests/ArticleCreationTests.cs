using FluentAssertions;
using iStore.Common.ClassLoading;
using iStore.Data.Access.DataIdentifiersMeta;
using iStore.Model.ArticleModelMeta;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iStore.Tests.Model.ArticleModelTests
{
    [TestClass]
    public class ArticleCreationTests
    {
        [TestMethod]
        public void ShouldBeAbleToCreateArticle()
        {
            var id = ServiceLoader.Instance.GetServiceWithValues<IIntValueDataIdentifier>(123);
            var article  = ServiceLoader.Instance.GetServiceWithValues<IArticle>(id, "Article name", "Article code");
            article.Id.Should().NotBe(default(object));
            article.Id.GetId().Should().NotBe(default(int));
            article.Name.Should().NotBe(default(string));
            article.Name.Should().NotBe(default(string));
        }

        [TestMethod]
        public void ShouldBeAbleToCreateSecondArticle()
        {
            var id = ServiceLoader.Instance.GetServiceWithValues<IIntValueDataIdentifier>(456);
            var article = ServiceLoader.Instance.GetServiceWithValues<IArticle>(id, "Second article name", "Second article code");
            article.Id.Should().NotBe(default(object));
            article.Id.GetId().Should().NotBe(default(int));
            article.Name.Should().NotBe(default(string));
            article.Name.Should().NotBe(default(string));
        }
    }
}
