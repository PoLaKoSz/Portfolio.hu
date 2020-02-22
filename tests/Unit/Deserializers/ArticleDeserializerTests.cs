using PoLaKoSz.hu.Portfolio_hu_API.Deserializers;
using PoLaKoSz.hu.Portfolio_hu_API.Models;
using HtmlAgilityPack;
using NUnit.Framework;

namespace UnitTests.Deserializers
{
    public class ArticleDeserializerTests
    {
        [Test]
        public void InvalidArticle__ShouldThrowException()
        {
            Assert.Throws<NodeNotFoundException>(() => ArticleDeserializer.Deserialize("<html></html>"));
        }

        [Test]
        public void ArticleWithoutTitle__ShouldThrowException()
        {
            Assert.Throws<NodeNotFoundException>(() => ArticleDeserializer.Deserialize("<div id=\"cikk\"></div>"));
        }

        [Test]
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
