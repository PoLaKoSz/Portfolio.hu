using NUnit.Framework;
using PoLaKoSz.Portfolio.EndPoints;
using PoLaKoSz.Portfolio.Models;

namespace PoLaKoSz.Portfolio.Tests.Regression.EndPoints
{
    class StockMarketEndPointTests
    {
        private static StockMarketEndPoint _endPoint;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            _endPoint = new StockMarketEndPoint();
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
