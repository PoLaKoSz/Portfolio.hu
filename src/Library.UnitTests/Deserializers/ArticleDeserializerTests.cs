using Library.Deserializers;
using Library.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Library.UnitTests.Deserializers
{
    [TestClass]
    public class ArticleDeserializerTests
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void InvalidArticle__ShouldThrowException()
        {
            ArticleDeserializer.Deserialize("<html></html>");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ArticleWithoutTitle__ShouldThrowException()
        {
            ArticleDeserializer.Deserialize("<div id=\"cikk\"></div>");
        }

        [TestMethod]
        public void ValidArticle__ShouldFindArticleTitle()
        {
            var expectedArticle = new PortfolioArticle("This library works! :)", "");

            var actualArticle = ArticleDeserializer.Deserialize(
"<div id=\"cikk\">"+
    "<table>"+
		"<tbody>"+
			"<tr>"+
				"<td></td>"+
				"<td>"+
					"<h1>"+
						"This library works! :)"+
					"</h1>"+
				"</td>"+
			"</tr>"+
		"</tbody>"+
	"</table>"+
"</div>");

            Assert.AreEqual(expectedArticle.Title, actualArticle.Title);
        }
    }
}
