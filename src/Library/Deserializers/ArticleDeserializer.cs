using HtmlAgilityPack;
using PoLaKoSz.hu.Portfolio_hu_API.Exceptions;
using PoLaKoSz.hu.Portfolio_hu_API.Models;

namespace PoLaKoSz.hu.Portfolio_hu_API.Deserializers
{
    public static class ArticleDeserializer
    {
        /// <summary>
        /// Extract the article from the raw source code
        /// </summary>
        /// <param name="sourceCode">Webpage source code</param>
        /// <returns></returns>
        /// <exception cref="NodeNotFoundException">Occurs when a deserialization failed</exception>
        /// <exception cref="ArchivedArticleException">Occurs when the article is not available for visitors</exception>
        public static Article Deserialize(string sourceCode)
        {
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(sourceCode);

            HtmlNode articleNode = ValidateArticle(document);

            return new Article(GetTitle(articleNode), GetBody(articleNode));
        }

        private static HtmlNode ValidateArticle(HtmlDocument htmlDocument)
        {
            var subscriptionTitleNode = htmlDocument
                .DocumentNode.SelectSingleNode("/html/body/div/div/div/table/tr/td/div[@class='greentitle']/div");

            if (subscriptionTitleNode != null &&
                subscriptionTitleNode.InnerText == "Elõfizetõi tartalom")
                throw new ArchivedArticleException("This article can't be parsed without a subscription!");

            var articleNode = htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"cikk\"]");

            if (articleNode == null)
                throw new NodeNotFoundException("Can't find DIV with ID cikk. This is not a valid article!");

            return articleNode;
        }

        private static string GetTitle(HtmlNode articleNode)
        {
            var titleNode = articleNode.SelectSingleNode("./h1");

            if (titleNode == null)
                throw new NodeNotFoundException("Can't find article title. This is not a valid article!");

            return titleNode.InnerText;
        }

        private static string GetBody(HtmlNode articleNode)
        {
            return articleNode.InnerText;
        }
    }
}
