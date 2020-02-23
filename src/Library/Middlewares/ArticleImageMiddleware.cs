using HtmlAgilityPack;

namespace PoLaKoSz.Portfolio.Middlewares
{
    /// <summary>
    /// Change every image's relative path to absolute path inside the article
    /// </summary>
    public class ArticleImageMiddleware : BaseMiddleware
    {
        /// <inheritdoc />
        public override HtmlNode PostEvent(HtmlNode rootNode)
        {
            HtmlNode articleNode = rootNode.SelectSingleNode("//*[@id=\"cikk\"]");

            if (articleNode == null)
            {
                return rootNode;
            }

            HtmlNodeCollection imageNodes = articleNode.SelectNodes("img");

            if (imageNodes == null)
            {
                return rootNode;
            }

            foreach (HtmlNode imageNode in imageNodes)
            {
                imageNode.SetAttributeValue("src", Constans.BaseAddress + imageNode.GetAttributeValue("src", string.Empty));
            }

            return articleNode;
        }
    }
}
