using Library.Deserializers;
using Library.Middlewares;
using Library.Models;
using System;

namespace Library
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
