using System.Collections.Generic;
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

        [Test]
        public void GetAvailableOptionsReturnsBiggerTickersLikeMolOtpMtelekom()
        {
            List<ShareType> mustHaveTickers = new List<ShareType>()
            {
                new ShareType("MOL"),
                new ShareType("MTELEKOM"),
                new ShareType("OTP"),
            };

            IEnumerable<ShareType> actual = _endPoint.GetAvailableOptions();

            CollectionAssert.IsSubsetOf(mustHaveTickers, actual);
        }
    }
}
