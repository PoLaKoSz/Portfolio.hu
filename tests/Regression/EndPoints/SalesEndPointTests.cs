using NUnit.Framework;
using PoLaKoSz.hu.Portfolio_hu_API.DataAccessLayer;
using PoLaKoSz.hu.Portfolio_hu_API.EndPoints;
using PoLaKoSz.hu.Portfolio_hu_API.Models;

namespace PoLaKoSz.hu.Portfolio_hu_API.Tests.Regression.EndPoints
{
    [TestFixture]
    public class SalesEndPointTests
    {
        private static SalesEndPoint _endPoint;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            _endPoint = new SalesEndPoint(new WebClient());
        }

        [TestCase("OTP")]
        [TestCase("MOL")]
        [TestCase("MTELEKOM")]
        public void TestWith(string tickerName)
        {
            var ticker = new ShareType(tickerName);
            _endPoint.For(ticker);
        }
    }
}
