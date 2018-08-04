using HtmlAgilityPack;
using PoLaKoSz.hu.Portfolio_hu_API.Models;
using System;

namespace PoLaKoSz.hu.Portfolio_hu_API.Deserializers
{
    public static class ArticleDeserializer
    {
        /// <summary>
        /// Extract the article from the raw source code
        /// </summary>
        /// <param name="sourceCode">Webpage source code</param>
        /// <returns></returns>
        public static PortfolioArticle Deserialize(string sourceCode)
        {
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(sourceCode);

            HtmlNode articleNode = ValidateArticle(document);

            return new PortfolioArticle(GetTitle(articleNode), GetBody(articleNode));
        }

        private static HtmlNode ValidateArticle(HtmlDocument htmlDocument)
        {
            var articleNode = htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"cikk\"]");

            if (articleNode == null)
                throw new Exception("This is not a valid article!");

            return articleNode;
        }

        private static string GetTitle(HtmlNode articleNode)
        {
            var titleNode = articleNode.SelectSingleNode("//table[1]/tbody/tr/td[2]/h1");

            if (titleNode == null)
                throw new Exception("Article title not found!");

            return titleNode.InnerText;
        }

        private static string GetBody(HtmlNode articleNode)
        {
            return articleNode.InnerText;
        }
    }
}
