using NUnit.Framework;
using PoLaKoSz.Portfolio.EndPoints;
using System;

namespace PoLaKoSz.Portfolio.Tests.Unit
{
    public class ArticleTests
    {
        [TestCase("https://www.google.com")]
        [TestCase("https://www.facebook.com")]
        [TestCase("https://youtube.com")]
        public void IsValidURL__NotPortfolioSite__ShouldReturnFalse(string url)
        {
            Uri address = new Uri(url);

            bool actual = ArticleEndPoint.IsValidURL(address);

            Assert.IsFalse(actual);
        }
        
        [TestCase("http://portfolio.hu")]
        [TestCase("https://portfolio.hu")]
        [TestCase("http://www.portfolio.hu")]
        [TestCase("https://www.portfolio.hu")]
        [TestCase("http://www.portfolio.hu/")]
        [TestCase("https://www.portfolio.hu/")]
        public void IsValidURL__PassHomepage__ShouldReturnFalse(string url)
        {
            Uri address = new Uri(url);

            bool actual = ArticleEndPoint.IsValidURL(address);

            Assert.IsFalse(actual);
        }

        [TestCase("https://forum.portfolio.hu/topics/ormester-reszvenyesek-ide/13684")]
        [TestCase("https://forum.portfolio.hu/topics/otp-reszvenyesek-ide/5224?oldal=50302")]
        [TestCase("https://forum.portfolio.hu/topics/komoly-biralatot-kapott-a-korrupcios-helyzet-miatt-magyarorszag-brusszelbol/26999")]
        public void IsValidURL__ForumURL__ShouldReturnFalse(string url)
        {
            Uri address = new Uri(url);

            bool actual = ArticleEndPoint.IsValidURL(address);

            Assert.IsFalse(actual);
        }

        [TestCase("https://www.portfolio.hu/arfolyam-panel/BET-BUX/bux-arfolyam.html")]
        [TestCase("https://www.portfolio.hu/arfolyam-panel/BET-OPUS/opus-reszveny-arfolyam.html")]
        public void IsValidURL__StockURL__ShouldReturnFalse(string url)
        {
            Uri address = new Uri(url);

            bool actual = ArticleEndPoint.IsValidURL(address);

            Assert.IsFalse(actual);
        }

        [TestCase("www.portfolio.hu/hir.php?i=294260")]
        [TestCase("http://portfolio.hu/hir.php?i=293194")]
        [TestCase("http://www.portfolio.hu/hir.php?i=293194")]
        [TestCase("http://www.portfolio.hu/prof/ok-ezert-lattak-elore-a-valasztasi-eredmenyt.287426.html")]
        [TestCase("https://www.portfolio.hu/impakt/csanyi-a-bankvilag-nem-a-kalandorok-helye.4.267115.html")]
        [TestCase("https://www.portfolio.hu/short/10-milliard-forintnyi-buntetesre-iteltek-egy-tinit-mert-erdotuzet-okozott.286466.html")]
        [TestCase("http://www.portfolio.hu/vallalatok/743-forintos-celar-erkezett-az-appeninnre-ugrik-az-arfolyam.290884.html?i=290884")]
        [TestCase("https://www.portfolio.hu/befektetes/befektetesi-alapok/eletbe-lepett-az-uj-eu-s-szabaly-itt-a-kegyelemdofes-a-bankbetetek-nagy-rivalisainak.292842.html")]
        public void IsValidURL__PassValidURL__ShouldReturnTrue(string url)
        {
            Uri address = new UriBuilder(url).Uri;

            bool actual = ArticleEndPoint.IsValidURL(address);

            Assert.IsTrue(actual);
        }
    }
}
