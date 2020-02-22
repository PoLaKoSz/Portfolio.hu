using System;

namespace PoLaKoSz.Portfolio.Models
{
    public class Article
    {
        public string Title { get; }
        public string Body { get; }



        public Article(string articleTitle, string articleBody)
        {
            Title = articleTitle;
            Body = articleBody;
        }
    }
}
