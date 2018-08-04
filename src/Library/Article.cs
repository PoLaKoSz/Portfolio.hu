using PoLaKoSz.hu.Portfolio_hu_API.Deserializers;
using PoLaKoSz.hu.Portfolio_hu_API.Middlewares;
using PoLaKoSz.hu.Portfolio_hu_API.Models;
using System;

namespace PoLaKoSz.hu.Portfolio_hu_API
{
    public class Article : EndPoint
    {
        public Article(Uri articleAddress)
            : base(articleAddress)
        {
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
    }
}
