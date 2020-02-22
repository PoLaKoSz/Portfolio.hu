using NUnit.Framework;
using PoLaKoSz.hu.Portfolio_hu_API.DataAccessLayer;
using PoLaKoSz.hu.Portfolio_hu_API.EndPoints;
using PoLaKoSz.hu.Portfolio_hu_API.Models;

namespace PoLaKoSz.hu.Portfolio_hu_API.Tests.Regression.EndPoints
{
    class StockMarketEndPointTests
    {
        private static StockMarketEndPoint _endPoint;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            _endPoint = new StockMarketEndPoint(new WebClient());
        }

        [Test]
        public void CanDeserializeForexStock()
        {
            _endPoint.Get(new ForeignCurrencyType("EURHUF=X"));
        }

        [Test]
        public void CanDeserializeShareStock()
        {
            _endPoint.Get(new ShareType("OTP"));
        }
    }
}
