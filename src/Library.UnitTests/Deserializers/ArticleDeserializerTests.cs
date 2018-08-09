using PoLaKoSz.hu.Portfolio_hu_API.Deserializers;
using PoLaKoSz.hu.Portfolio_hu_API.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HtmlAgilityPack;
using PoLaKoSz.hu.Portfolio_hu_API.Exceptions;

namespace UnitTests.Deserializers
{
    [TestClass]
    public class ArticleDeserializerTests
    {
        [TestMethod]
        [ExpectedException(typeof(NodeNotFoundException))]
        public void InvalidArticle__ShouldThrowException()
        {
            ArticleDeserializer.Deserialize("<html></html>");
        }

        [TestMethod]
        [ExpectedException(typeof(NodeNotFoundException))]
        public void ArticleWithoutTitle__ShouldThrowException()
        {
            ArticleDeserializer.Deserialize("<div id=\"cikk\"></div>");
        }

        [TestMethod]
        [ExpectedException(typeof(ArchivedArticleException))]
        public void ArchivedArchive__ShouldThrowArchivedArticleException()
        {
            ArticleDeserializer.Deserialize("<div class=\"greentitle\"><h1>\n Előfizetői tartalom\n</h1></div>");
        }

        [TestMethod]
        public void ValidArticle__ShouldFindArticleTitle()
        {
            var expectedArticle = new Article("This library works! :)", "");

            var actualArticle = ArticleDeserializer.Deserialize(
"<div id=\"cikk\">"+
    "<h1>"+
        "This library works! :)"+
	"</h1>"+
"</div>");

            Assert.AreEqual(expectedArticle.Title, actualArticle.Title);
        }
    }
}
