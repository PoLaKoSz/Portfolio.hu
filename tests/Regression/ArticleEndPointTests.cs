using NUnit.Framework;
using PoLaKoSz.Portfolio.Exceptions;
using System;

namespace PoLaKoSz.Portfolio.Tests.Regression
{
    class ArticleEndPointTests
    {
        [TestCaseSource(nameof(_validURLs))]
        public void ValidUrls(Uri url)
        {
            var ex = Assert.Throws<Exception>(() => new ArticleEndPoint(url).Load());

            Assert.That(ex.InnerException.Message, Is.EqualTo("This article can't be parsed without a subscription!"));
            Assert.That(ex.InnerException, Is.TypeOf(typeof(ArchivedArticleException)));
        }


        private static Uri[] _validURLs = new Uri[]
        {
            new Uri("https://www.portfolio.hu/vallalatok/emelkedessel-zarta-a-kedd-kereskedest-a-bux.4.311261.html"),
            new Uri("https://www.portfolio.hu/gazdasag/a-kubai-raketavalsag-ota-nem-voltunk-ilyen-kozel-az-atomhaboruhoz.4.311347.html"),
        };
    }
}
