using System;
using System.Threading.Tasks;
using NUnit.Framework;
using PoLaKoSz.Portfolio.EndPoints;
using PoLaKoSz.Portfolio.Models;

namespace PoLaKoSz.Portfolio.Tests.Regression.EndPoints
{
    [TestFixture]
    internal class StockMarketEndPointTests
    {
        private static IStockMarketEndPoint _endPoint;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            _endPoint = new Portfolio().StockMarket;
        }

        [Test]
        public async Task ForeignCurrencyTypeLastDay()
        {
            await _endPoint.Get(new ForeignCurrencyType("EURHUF=X")).LastDay();
        }

        [Test]
        public async Task ShareTypeLastDay()
        {
            await _endPoint.Get(new ShareType("OTP")).LastDay();
        }

        [Test]
        public async Task CanDeserializeLastDayIntervalForexStock()
        {
            await _endPoint.GetForeignCurrency(request => request.LastDay().For(new ForeignCurrencyType("EURHUF=X")))
                .ConfigureAwait(false);
        }

        [Test]
        public async Task CanDeserializeLastMonthIntervalForexStock()
        {
            await _endPoint.GetForeignCurrency(request => request.LastMonth().For(new ForeignCurrencyType("EURHUF=X")))
                .ConfigureAwait(false);
        }

        [Test]
        public async Task CanDeserializeLastMonthIntervalForexStock()
        {
            await _endPoint.Get(new ForeignCurrencyType("EURHUF=X").LastMonth()
                .ConfigureAwait(false);
        }

        [Test]
        public async Task CanDeserializeLastThreeMonthIntervalForexStock()
        {
            await _endPoint.GetForeignCurrency(request => request.LastThreeMonth().For(new ForeignCurrencyType("EURHUF=X")))
                .ConfigureAwait(false);
        }

        [Test]
        public async Task CanDeserializeLastSixMonthIntervalForexStock()
        {
            await _endPoint.GetForeignCurrency(request => request.LastSixMonth().For(new ForeignCurrencyType("EURHUF=X")))
                .ConfigureAwait(false);
        }

        [Test]
        public async Task CanDeserializeLastYearIntervalForexStock()
        {
            ForeignCurrency actual = await _endPoint.GetForeignCurrency(request => request.LastYear().For(new ForeignCurrencyType("EURHUF=X")))
                .ConfigureAwait(false);
            System.Console.WriteLine();
        }

        [Test]
        public async Task CanDeserializeLastFiveYearIntervalForexStock()
        {
            await _endPoint.GetForeignCurrency(request => request.LastFiveYear().For(new ForeignCurrencyType("EURHUF=X")))
                .ConfigureAwait(false);
        }

        [Test]
        public async Task CanDeserializeShareStock()
        {
            await _endPoint.GetShare(request => request.LastDay().For(new ShareType("OTP")))
                .ConfigureAwait(false);
        }

        private bool IsWeekend()
        {
            DateTime now = DateTime.UtcNow;
            return now.DayOfWeek == DayOfWeek.Saturday || now.DayOfWeek == DayOfWeek.Sunday;
        }
    }
}
