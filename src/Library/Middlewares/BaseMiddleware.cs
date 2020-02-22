using HtmlAgilityPack;

namespace PoLaKoSz.Portfolio.Middlewares
{
    public abstract class BaseMiddleware
    {
        /// <summary>
        /// Modify the <see cref="EndPoint"/> before the web request
        /// </summary>
        /// <param name="endPoint"></param>
        public virtual void PreEvent(EndPoint endPoint)
        {

        }

        /// <summary>
        /// Modify the response from the previous middleware or the actual web response
        /// </summary>
        /// <param name="rootNode">Modified rootnode by middlewares from the web response</param>
        /// <returns>Method parameter without modification</returns>
        public virtual HtmlNode PostEvent(HtmlNode rootNode)
        {
            return rootNode;
        }
    }
}
