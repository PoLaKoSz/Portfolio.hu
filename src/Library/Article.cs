using PoLaKoSz.hu.Portfolio_hu_API.Deserializers;
using PoLaKoSz.hu.Portfolio_hu_API.Middlewares;
using PoLaKoSz.hu.Portfolio_hu_API.Models;
using System;

namespace PoLaKoSz.hu.Portfolio_hu_API
{
    public class Article : EndPoint
    {
        /// <summary>
        /// Initialize a new Article endpoint
        /// </summary>
        /// <param name="articleAddress"></param>
        /// <exception cref="ArgumentException">Occurs when the passed <see cref="Uri"/> is not valid</exception>
        public Article(Uri articleAddress)
            : base(articleAddress)
        {
            if (!IsValidURL(articleAddress))
                throw new ArgumentException("URL " + articleAddress.ToString() + " is not a valid article!");

            Middlewares.Add(new ArticleImageMiddleware());
        }



        /// <summary>
        /// Return the desired Portfolio article
        /// </summary>
        /// <returns></returns>
        public PortfolioArticle Load()
        {
            string sourceCode = base.LoadWebpage();

            return ArticleDeserializer.Deserialize(sourceCode);
        }

        /// <summary>
        /// Determinate that the given <see cref="Uri"/> is a valid article URL
        /// </summary>
        /// <param name="articleAddress">Questionable URL</param>
        /// <returns></returns>
        public static bool IsValidURL(Uri articleAddress)
        {
            if (!(articleAddress.Host.Equals("portfolio.hu") ||
                articleAddress.Host.Equals("www.portfolio.hu")))
                return false;

            if (!(3 <= articleAddress.Segments.Length ||
                articleAddress.AbsolutePath.Contains("hir.php")))
                return false;

            if (articleAddress.Segments[1].Equals("arfolyam-panel/"))
                return false;

            return true;
        }
    }
}
