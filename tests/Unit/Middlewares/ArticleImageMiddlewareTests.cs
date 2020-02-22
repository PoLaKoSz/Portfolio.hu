using HtmlAgilityPack;
using PoLaKoSz.Portfolio.Middlewares;
using NUnit.Framework;

namespace PoLaKoSz.Portfolio.Tests.Unit.Middlewares
{
    public class ArticleImageMiddlewareTests
    {
        private static ArticleImageMiddleware _middleware;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            _middleware = new ArticleImageMiddleware();
        }

        [Test]
        public void NoImageFound__NoChangesIntroduced()
        {
            var expected = HtmlNode.CreateNode("<div>Hello</div>");

            var actual = _middleware.PostEvent(expected);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OneImage__ShouldChangeLocalPath()
        {
            var testNode = HtmlNode.CreateNode("<div id=\"cikk\"><img src=\"/img/upload/2018/07/6-20180726.png\"></div>");
            var expected = HtmlNode.CreateNode("<div id=\"cikk\"><img src=\"" + Constans.BaseAddress + "/img/upload/2018/07/6-20180726.png\"></div>");

            var actual = _middleware.PostEvent(testNode);

            Assert.AreEqual(expected.InnerHtml, actual.InnerHtml);
        }
    }
}
