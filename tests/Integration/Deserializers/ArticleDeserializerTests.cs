using NUnit.Framework;
using PoLaKoSz.hu.Portfolio_hu_API.Deserializers;
using PoLaKoSz.hu.Portfolio_hu_API.Exceptions;
using PoLaKoSz.hu.Portfolio_hu_API.Models;

namespace Library.Tests.Integration.Deserializers
{
    class ArticleDeserializerTests : TestClassBase
    {
        public ArticleDeserializerTests()
            : base("articles") { }

        [Test]
        public void ArchivedArchive__ShouldThrowArchivedArticleException()
        {
            string sourceCode = base.GetTestData("archived");

            Assert.Throws<ArchivedArticleException>(() => ArticleDeserializer.Deserialize(sourceCode));
        }

        [Test]
        public void ValidArticle__ShouldFindArticleTitle()
        {
            var expectedArticle = new Article("Gigantikusra nőtt a magyar állam - Most kell tízezreket utcára tenni?", "");

            string sourceCode = base.GetTestData("valid");

            var actual = ArticleDeserializer.Deserialize( sourceCode );

            Assert.AreEqual(expectedArticle.Title, actual.Title);
        }
    }
}
