using Microsoft.VisualStudio.TestTools.UnitTesting;
using PoLaKoSz.hu.Portfolio_hu_API.Deserializers;
using PoLaKoSz.hu.Portfolio_hu_API.Exceptions;
using PoLaKoSz.hu.Portfolio_hu_API.Models;
using System.IO;

namespace Library.Tests.Integration.Deserializers
{
    [TestClass]
    public class ArticleDeserializerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArchivedArticleException))]
        public void ArchivedArchive__ShouldThrowArchivedArticleException()
        {
            string sourceCode = File.ReadAllText("StaticResources\\article_archived.html");

            ArticleDeserializer.Deserialize(sourceCode);
        }


        [TestMethod]
        public void ValidArticle__ShouldFindArticleTitle()
        {
            var expectedArticle = new Article("Gigantikusra nőtt a magyar állam - Most kell tízezreket utcára tenni?", "");

            string sourceCode = File.ReadAllText("StaticResources\\article_valid.html");

            var actual = ArticleDeserializer.Deserialize( sourceCode );

            Assert.AreEqual(expectedArticle.Title, actual.Title);
        }
    }
}
