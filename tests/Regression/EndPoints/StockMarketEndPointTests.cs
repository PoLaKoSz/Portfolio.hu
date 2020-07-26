using System.Threading.Tasks;
using NUnit.Framework;
using PoLaKoSz.Portfolio.EndPoints;
using PoLaKoSz.Portfolio.Models;

namespace PoLaKoSz.Portfolio.Tests.Regression.EndPoints
{
    class StockMarketEndPointTests
    {
        private static IStockMarketEndPoint _endPoint;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            _endPoint = new Portfolio().StockMarket;
        }

        [Test]
        public async Task CanDeserializeForexStock()
        {
            await _endPoint.Get(new ForeignCurrencyType("EURHUF=X"))
                .ConfigureAwait(false);
        }

        [Test]
        public async Task CanDeserializeShareStock()
        {
            await _endPoint.Get(new ShareType("OTP"))
                .ConfigureAwait(false);
        }
    }
}
