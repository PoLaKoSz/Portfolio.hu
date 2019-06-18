using NUnit.Framework;
using PoLaKoSz.hu.Portfolio_hu_API.Deserializers;
using PoLaKoSz.hu.Portfolio_hu_API.Exceptions;
using PoLaKoSz.hu.Portfolio_hu_API.Models;
using System.IO;

namespace Library.Tests.Integration.Deserializers
{
    public class ArticleDeserializerTests
    {
        [Test]
        public void ArchivedArchive__ShouldThrowArchivedArticleException()
        {
            string sourceCode = File.ReadAllText("StaticResources/article_archived.html");

            Assert.Throws<ArchivedArticleException>(() => ArticleDeserializer.Deserialize(sourceCode));
        }

        [Test]
        public void ValidArticle__ShouldFindArticleTitle()
        {
            var expectedArticle = new Article("Gigantikusra nőtt a magyar állam - Most kell tízezreket utcára tenni?", "");

            string sourceCode = File.ReadAllText("StaticResources\\article_valid.html");

            var actual = ArticleDeserializer.Deserialize( sourceCode );

            Assert.AreEqual(expectedArticle.Title, actual.Title);
        }
    }
}
