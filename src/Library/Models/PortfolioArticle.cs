using System;

namespace Library.Models
{
    public class PortfolioArticle
    {
        public string Title { get; }
        public string Body { get; }



        public PortfolioArticle(string articleTitle, string articleBody)
        {
            Title = articleTitle;
            Body = articleBody;
        }
    }
}
