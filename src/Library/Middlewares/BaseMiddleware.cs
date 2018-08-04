using HtmlAgilityPack;

namespace PoLaKoSz.hu.Portfolio_hu_API.Middlewares
{
    public abstract class BaseMiddleware
    {
        public virtual void PreEvent(EndPoint endPoint)
        {

        }

        /// <summary>
        /// Gets the root node of the sourceCode
        /// </summary>
        /// <param name="sourceCode">Root HtmlNode of the sourcecode</param>
        /// <returns></returns>
        public virtual HtmlNode PostEvent(HtmlNode rootNode)
        {
            return rootNode;
        }
    }
}
