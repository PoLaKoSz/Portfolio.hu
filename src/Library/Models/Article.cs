using System;

namespace PoLaKoSz.hu.Portfolio_hu_API.Models
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
