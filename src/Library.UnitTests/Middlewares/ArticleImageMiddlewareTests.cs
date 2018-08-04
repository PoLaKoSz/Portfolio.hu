using HtmlAgilityPack;
using PoLaKoSz.hu.Portfolio_hu_API;
using PoLaKoSz.hu.Portfolio_hu_API.Middlewares;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Library_UnitTests.Middlewares
{
    [TestClass]
    public class ArticleImageMiddlewareTests
    {
        private static ArticleImageMiddleware _middleware { get; set; }



        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            _middleware = new ArticleImageMiddleware();
        }



        [TestMethod]
        public void NoImageFound__NoChangesIntroduced()
        {
            var expected = HtmlNode.CreateNode("<div>Hello</div>");

            var actual = _middleware.PostEvent(expected);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OneImage__ShouldChangeLocalPath()
        {
            var testNode = HtmlNode.CreateNode("<div id=\"cikk\"><img src=\"/img/upload/2018/07/6-20180726.png\"></div>");
            var expected = HtmlNode.CreateNode("<div id=\"cikk\"><img src=\"" + Constans.BaseAddress + "/img/upload/2018/07/6-20180726.png\"></div>");

            var actual = _middleware.PostEvent(testNode);

            Assert.AreEqual(expected.InnerHtml, actual.InnerHtml);
        }
    }
}
