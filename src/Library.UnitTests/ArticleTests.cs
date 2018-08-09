using Microsoft.VisualStudio.TestTools.UnitTesting;
using PoLaKoSz.hu.Portfolio_hu_API;
using System;

namespace UnitTests
{
    [TestClass]
    public class ArticleTests
    {

        [DataTestMethod]
        [DataRow("https://www.google.com")]
        [DataRow("https://www.facebook.com")]
        [DataRow("https://youtube.com")]
        public void IsValidURL__NotPortfolioSite__ShouldReturnFalse(string url)
        {
            Uri address = new Uri(url);

            bool actual = ArticleEndPoint.IsValidURL(address);

            Assert.AreEqual(false, actual);
        }
        
        [DataTestMethod]
        [DataRow("http://portfolio.hu")]
        [DataRow("https://portfolio.hu")]
        [DataRow("http://www.portfolio.hu")]
        [DataRow("https://www.portfolio.hu")]
        [DataRow("http://www.portfolio.hu/")]
        [DataRow("https://www.portfolio.hu/")]
        public void IsValidURL__PassHomepage__ShouldReturnFalse(string url)
        {
            Uri address = new Uri(url);

            bool actual = ArticleEndPoint.IsValidURL(address);

            Assert.AreEqual(false, actual);
        }

        [DataTestMethod]
        [DataRow("https://forum.portfolio.hu/topics/ormester-reszvenyesek-ide/13684")]
        [DataRow("https://forum.portfolio.hu/topics/otp-reszvenyesek-ide/5224?oldal=50302")]
        [DataRow("https://forum.portfolio.hu/topics/komoly-biralatot-kapott-a-korrupcios-helyzet-miatt-magyarorszag-brusszelbol/26999")]
        public void IsValidURL__ForumURL__ShouldReturnFalse(string url)
        {
            Uri address = new Uri(url);

            bool actual = ArticleEndPoint.IsValidURL(address);

            Assert.AreEqual(false, actual);
        }

        [DataTestMethod]
        [DataRow("https://www.portfolio.hu/arfolyam-panel/BET-BUX/bux-arfolyam.html")]
        [DataRow("https://www.portfolio.hu/arfolyam-panel/BET-OPUS/opus-reszveny-arfolyam.html")]
        public void IsValidURL__StockURL__ShouldReturnFalse(string url)
        {
            Uri address = new Uri(url);

            bool actual = ArticleEndPoint.IsValidURL(address);

            Assert.AreEqual(false, actual);
        }

        [DataTestMethod]
        [DataRow("http://portfolio.hu/hir.php?i=293194")]
        [DataRow("http://www.portfolio.hu/hir.php?i=293194")]
        [DataRow("http://www.portfolio.hu/prof/ok-ezert-lattak-elore-a-valasztasi-eredmenyt.287426.html")]
        [DataRow("https://www.portfolio.hu/impakt/csanyi-a-bankvilag-nem-a-kalandorok-helye.4.267115.html")]
        [DataRow("https://www.portfolio.hu/short/10-milliard-forintnyi-buntetesre-iteltek-egy-tinit-mert-erdotuzet-okozott.286466.html")]
        [DataRow("http://www.portfolio.hu/vallalatok/743-forintos-celar-erkezett-az-appeninnre-ugrik-az-arfolyam.290884.html?i=290884")]
        [DataRow("https://www.portfolio.hu/befektetes/befektetesi-alapok/eletbe-lepett-az-uj-eu-s-szabaly-itt-a-kegyelemdofes-a-bankbetetek-nagy-rivalisainak.292842.html")]
        public void IsValidURL__PassValidURL__ShouldReturnTrue(string url)
        {
            Uri address = new Uri(url);

            bool actual = ArticleEndPoint.IsValidURL(address);

            Assert.AreEqual(true, actual);
        }
    }
}
