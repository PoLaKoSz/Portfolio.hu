using PoLaKoSz.Portfolio.Tests.Integration.DataAccessLayer;
using NUnit.Framework;
using PoLaKoSz.Portfolio.EndPoints;
using PoLaKoSz.Portfolio.Models;

namespace PoLaKoSz.Portfolio.Tests.Integration.EndPoints
{
    class StockMarketEndPointTests
    {
        private static readonly object[] _allStocks;
        private static readonly object[] _onlyForex;
        private static readonly object[] _onlyShare;

        static StockMarketEndPointTests()
        {
            var expectedForexStock = StaticResources.Stocks.EurHuf.Get();
            GetDataFrom("EurHuf", out ForeignCurrency actualForexStock);

            var expectedShareWithoutBidAndAsk = StaticResources.Stocks.ShareWithoutBidAsk.Get();
            GetDataFrom("Share-without-bid-and-ask", out Share actualShareWithoutBidAndAsk);

            var expectedShareWhenTradingDidNotStartedYet = StaticResources.Stocks.ShareWhenTradingDidNotStartedYet.Get();
            GetDataFrom("Share-when-trading-did-not-started-yet", out Share actualShareWhenTradingDidNotStartedYet);

            _allStocks = new object[]
            {
                new object[]{ expectedForexStock, actualForexStock },
                new object[]{ expectedShareWithoutBidAndAsk, actualShareWithoutBidAndAsk },
                new object[]{ expectedShareWhenTradingDidNotStartedYet, actualShareWhenTradingDidNotStartedYet },
            };

            _onlyForex = new object[]
            {
                new object[]{ expectedForexStock, actualForexStock },
            };

            _onlyShare = new object[]
            {
                new object[]{ expectedShareWithoutBidAndAsk, actualShareWithoutBidAndAsk },
                new object[]{ expectedShareWhenTradingDidNotStartedYet, actualShareWhenTradingDidNotStartedYet },
            };
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockIsStarted(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.IsStarted, actual.IsStarted, nameof(ForeignCurrency.IsStarted));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockTickerID(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.TickerID, actual.TickerID, nameof(ForeignCurrency.TickerID));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockTicker(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.Ticker, actual.Ticker, nameof(ForeignCurrency.Ticker));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockType(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.Type, actual.Type, nameof(ForeignCurrency.Type));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockFullName(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.FullName, actual.FullName, nameof(ForeignCurrency.FullName));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockPrefix(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.Prefix, actual.Prefix, nameof(ForeignCurrency.Prefix));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockCurrency(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.Currency, actual.Currency, nameof(ForeignCurrency.Currency));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockISIN(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.ISIN, actual.ISIN, nameof(ForeignCurrency.ISIN));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockName(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.Name, actual.Name, nameof(ForeignCurrency.Name));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockShortName(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.ShortName, actual.ShortName, nameof(ForeignCurrency.ShortName));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockChartName(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.ChartName, actual.ChartName, nameof(ForeignCurrency.ChartName));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockDecimals(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.Decimals, actual.Decimals, nameof(ForeignCurrency.Decimals));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockForgDecimals(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.ForgDecimals, actual.ForgDecimals, nameof(ForeignCurrency.ForgDecimals));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockOpen(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.Open, actual.Open, nameof(ForeignCurrency.Open));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockClose(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.Close, actual.Close, nameof(ForeignCurrency.Close));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockLast(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.Last, actual.Last, nameof(ForeignCurrency.Last));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockLastHTML(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.LastHTML, actual.LastHTML, nameof(ForeignCurrency.LastHTML));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockLastSize(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.LastSize, actual.LastSize, nameof(ForeignCurrency.LastSize));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockLastTime(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.LastTime, actual.LastTime, nameof(ForeignCurrency.LastTime));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockLastHtmlTime(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.LastHtmlTime, actual.LastHtmlTime, nameof(ForeignCurrency.LastHtmlTime));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockChange(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.Change, actual.Change, nameof(ForeignCurrency.Change));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockChangePercentage(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.ChangePercentage, actual.ChangePercentage, nameof(ForeignCurrency.ChangePercentage));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockMin(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.Min, actual.Min, nameof(ForeignCurrency.Min));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockMax(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.Max, actual.Max, nameof(ForeignCurrency.Max));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockDealsCount(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.DealsCount, actual.DealsCount, nameof(ForeignCurrency.DealsCount));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockDeals(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.Deals, actual.Deals, nameof(ForeignCurrency.Deals));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockTraffic(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.Traffic, actual.Traffic, nameof(ForeignCurrency.Traffic));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockTrafficCount(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.TrafficCount, actual.TrafficCount, nameof(ForeignCurrency.TrafficCount));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockOpenInterest(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.OpenInterest, actual.OpenInterest, nameof(ForeignCurrency.OpenInterest));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockStatus(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.Status, actual.Status, nameof(ForeignCurrency.Status));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockPanelJS(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.PanelJS, actual.PanelJS, nameof(ForeignCurrency.PanelJS));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockID(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.ID, actual.ID, nameof(ForeignCurrency.ID));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockRealTime(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.RealTime, actual.RealTime, nameof(ForeignCurrency.RealTime));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockPe2000(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.Pe2000, actual.Pe2000, nameof(ForeignCurrency.Pe2000));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockPe2001(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.Pe2001, actual.Pe2001, nameof(ForeignCurrency.Pe2001));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockCloseOneMonth(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.CloseOneMonth, actual.CloseOneMonth, nameof(ForeignCurrency.CloseOneMonth));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockCloseOneMonthInterval(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.CloseOneMonthInterval, actual.CloseOneMonthInterval, nameof(ForeignCurrency.CloseOneMonthInterval));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockCloseThreeMonth(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.CloseThreeMonth, actual.CloseThreeMonth, nameof(ForeignCurrency.CloseThreeMonth));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockCloseThreeMonthInterval(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.CloseThreeMonthInterval, actual.CloseThreeMonthInterval, nameof(ForeignCurrency.CloseThreeMonthInterval));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockCloseOneYear(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.CloseOneYear, actual.CloseOneYear, nameof(ForeignCurrency.CloseOneYear));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockCloseOneYearInterval(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.CloseOneYearInterval, actual.CloseOneYearInterval, nameof(ForeignCurrency.CloseOneYearInterval));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockOneMonthVolatility(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.OneMonthVolatility, actual.OneMonthVolatility, nameof(ForeignCurrency.OneMonthVolatility));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockThreeMonthVolatility(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.ThreeMonthVolatility, actual.ThreeMonthVolatility, nameof(ForeignCurrency.ThreeMonthVolatility));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockOneYearVolatility(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.OneYearVolatility, actual.OneYearVolatility, nameof(ForeignCurrency.OneYearVolatility));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockEps2000(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.Eps2000, actual.Eps2000, nameof(ForeignCurrency.Eps2000));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockEps2001(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.Eps2001, actual.Eps2001, nameof(ForeignCurrency.Eps2001));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockMinOneYear(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.MinOneYear, actual.MinOneYear, nameof(ForeignCurrency.MinOneYear));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockMinOneYearAt(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.MinOneYearAt, actual.MinOneYearAt, nameof(ForeignCurrency.MinOneYearAt));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockMaxOneYear(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.MaxOneYear, actual.MaxOneYear, nameof(ForeignCurrency.MaxOneYear));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockMaxOneYearAt(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.MaxOneYearAt, actual.MaxOneYearAt, nameof(ForeignCurrency.MaxOneYearAt));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockMinOfAllTime(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.MinOfAllTime, actual.MinOfAllTime, nameof(ForeignCurrency.MinOfAllTime));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockMinOfAllTimeAt(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.MinOfAllTimeAt, actual.MinOfAllTimeAt, nameof(ForeignCurrency.MinOfAllTimeAt));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockMaxOfAllTime(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.MaxOfAllTime, actual.MaxOfAllTime, nameof(ForeignCurrency.MaxOfAllTime));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockMaxOfAllTimeAt(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.MaxOfAllTimeAt, actual.MaxOfAllTimeAt, nameof(ForeignCurrency.MaxOfAllTimeAt));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockCloseMinOneYear(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.CloseMinOneYear, actual.CloseMinOneYear, nameof(ForeignCurrency.CloseMinOneYear));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockCloseMinOneYearAt(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.CloseMinOneYearAt, actual.CloseMinOneYearAt, nameof(ForeignCurrency.CloseMinOneYearAt));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockCloseMaxOneYear(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.CloseMaxOneYear, actual.CloseMaxOneYear, nameof(ForeignCurrency.CloseMaxOneYear));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockCloseMaxOneYearAt(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.CloseMaxOneYearAt, actual.CloseMaxOneYearAt, nameof(ForeignCurrency.CloseMaxOneYearAt));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockCloseMinAllTime(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.CloseMinAllTime, actual.CloseMinAllTime, nameof(ForeignCurrency.CloseMinAllTime));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockCloseMinAllTimeAt(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.CloseMinAllTimeAt, actual.CloseMinAllTimeAt, nameof(ForeignCurrency.CloseMinAllTimeAt));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockCloseMaxAllTime(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.CloseMaxOfAllTime, actual.CloseMaxOfAllTime, nameof(ForeignCurrency.CloseMaxOfAllTime));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockCloseMaxAllTimeAt(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.CloseMaxAllTimeAt, actual.CloseMaxAllTimeAt, nameof(ForeignCurrency.CloseMaxAllTimeAt));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockTrafficAvgInSixMonth(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.TrafficAvgInSixMonth, actual.TrafficAvgInSixMonth, nameof(ForeignCurrency.TrafficAvgInSixMonth));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockTrafficAvgInOneYear(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.TrafficAvgInOneYear, actual.TrafficAvgInOneYear, nameof(ForeignCurrency.TrafficAvgInOneYear));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockStartCount(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.StartCount, actual.StartCount, nameof(ForeignCurrency.StartCount));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockKapit(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.Kapit, actual.Kapit, nameof(ForeignCurrency.Kapit));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockBuxKapit(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.BuxKapit, actual.BuxKapit, nameof(ForeignCurrency.BuxKapit));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockChangeInOneMonth(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.ChangeInOneMonth, actual.ChangeInOneMonth, nameof(ForeignCurrency.ChangeInOneMonth));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockChangeInThreeMonth(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.ChangeInThreeMonth, actual.ChangeInThreeMonth, nameof(ForeignCurrency.ChangeInThreeMonth));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockChangeInOneYear(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.ChangeInOneYear, actual.ChangeInOneYear, nameof(ForeignCurrency.ChangeInOneYear));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockStartPrice(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.StartPrice, actual.StartPrice, nameof(ForeignCurrency.StartPrice));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockMinInOneYear(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.MinInOneYear, actual.MinInOneYear, nameof(ForeignCurrency.MinInOneYear));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockMaxInOneYear(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.MaxInOneYear, actual.MaxInOneYear, nameof(ForeignCurrency.MaxInOneYear));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockImageDataStartTime(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.ImageData?.StartTime, actual.ImageData?.StartTime, nameof(ChartData.StartTime));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockImageDataEndTime(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.ImageData?.EndTime, actual.ImageData?.EndTime, nameof(ChartData.EndTime));
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockImageDataPrices(Stock expected, Stock actual)
        {
            if (expected.ImageData == null && actual.ImageData == null)
            {
                var stock = (Share)expected;
                Assert.Pass($"This financial asset only tradeable between {stock.OpenTime} and {stock.CloseTime}.");
            }

            var expectedPrices = expected.ImageData.Prices;
            var actualPrices = actual.ImageData.Prices;

            if (expectedPrices.Count != actualPrices.Count)
            {
                Assert.Fail($"Expected is with {expectedPrices.Count} elements, actual is with {actualPrices.Count} elements");
            }

            for (int i = 0; i < expectedPrices.Count; i++)
            {
                var expectedPrice = expectedPrices[i];
                var actualPrice = expectedPrices[i];

                Assert.AreEqual(expectedPrice.Value,   actualPrice.Value,   $"#{i} {nameof(StockPrice.Value)}");
                Assert.AreEqual(expectedPrice.At,      actualPrice.At,      $"#{i} {nameof(StockPrice.At)}");
                Assert.AreEqual(expectedPrice.Traffic, actualPrice.Traffic, $"#{i} {nameof(StockPrice.Traffic)}");
            }
        }

        [TestCaseSource(nameof(_allStocks))]
        public void CanDeserializeStockImageDataDateFormat(Stock expected, Stock actual)
        {
            Assert.AreEqual(expected.ImageData?.DateFormat, actual.ImageData?.DateFormat, nameof(ChartData.DateFormat));
        }

        [TestCaseSource(nameof(_onlyForex))]
        public void CanDeserializeForexMarkersID(ForeignCurrency expected, ForeignCurrency actual)
        {
            Assert.AreEqual(expected.MarkersID, actual.MarkersID, nameof(ForeignCurrency.MarkersID));
        }

        [TestCaseSource(nameof(_onlyForex))]
        public void CanDeserializeForexMarketCode(ForeignCurrency expected, ForeignCurrency actual)
        {
            Assert.AreEqual(expected.MarketCode, actual.MarketCode, nameof(ForeignCurrency.MarketCode));
        }

        [TestCaseSource(nameof(_onlyForex))]
        public void CanDeserializeForexDataStart(ForeignCurrency expected, ForeignCurrency actual)
        {
            Assert.AreEqual(expected.DataStart, actual.DataStart, nameof(ForeignCurrency.DataStart));
        }

        [TestCaseSource(nameof(_onlyForex))]
        public void CanDeserializeForexDataEnd(ForeignCurrency expected, ForeignCurrency actual)
        {
            Assert.AreEqual(expected.DataEnd, actual.DataEnd, nameof(ForeignCurrency.DataEnd));
        }

        [TestCaseSource(nameof(_onlyShare))]
        public void CanDeserializeShareSubGroup(Share expected, Share actual)
        {
            Assert.AreEqual(expected.SubGroup, actual.SubGroup, nameof(Share.SubGroup));
        }

        [TestCaseSource(nameof(_onlyShare))]
        public void CanDeserializeShareOpenTime(Share expected, Share actual)
        {
            Assert.AreEqual(expected.OpenTime, actual.OpenTime, nameof(Share.OpenTime));
        }

        [TestCaseSource(nameof(_onlyShare))]
        public void CanDeserializeShareCloseTime(Share expected, Share actual)
        {
            Assert.AreEqual(expected.CloseTime, actual.CloseTime, nameof(Share.CloseTime));
        }

        [TestCaseSource(nameof(_onlyShare))]
        public void CanDeserializeShareMarket(Share expected, Share actual)
        {
            Assert.AreEqual(expected.Market, actual.Market, nameof(Share.Market));
        }

        [TestCaseSource(nameof(_onlyShare))]
        public void CanDeserializeShareBoard(Share expected, Share actual)
        {
            Assert.AreEqual(expected.Board, actual.Board, nameof(Share.Board));
        }

        [TestCaseSource(nameof(_onlyShare))]
        public void CanDeserializeShareD(Share expected, Share actual)
        {
            Assert.AreEqual(expected.D, actual.D, nameof(Share.D));
        }

        [TestCaseSource(nameof(_onlyShare))]
        public void CanDeserializeShareSuly(Share expected, Share actual)
        {
            Assert.AreEqual(expected.Suly, actual.Suly, nameof(Share.Suly));
        }

        [TestCaseSource(nameof(_onlyShare))]
        public void CanDeserializeShareDBumix(Share expected, Share actual)
        {
            Assert.AreEqual(expected.DBumix, actual.DBumix, nameof(Share.DBumix));
        }

        [TestCaseSource(nameof(_onlyShare))]
        public void CanDeserializeShareSulyBumix(Share expected, Share actual)
        {
            Assert.AreEqual(expected.SulyBumix, actual.SulyBumix, nameof(Share.SulyBumix));
        }

        [TestCaseSource(nameof(_onlyShare))]
        public void CanDeserializeShareMovingCount(Share expected, Share actual)
        {
            Assert.AreEqual(expected.MovingCount, actual.MovingCount, nameof(Share.MovingCount));
        }

        [TestCaseSource(nameof(_onlyShare))]
        public void CanDeserializeShareExpire(Share expected, Share actual)
        {
            Assert.AreEqual(expected.Expire, actual.Expire, nameof(Share.Expire));
        }

        [TestCaseSource(nameof(_onlyShare))]
        public void CanDeserializeShareInterestRate(Share expected, Share actual)
        {
            Assert.AreEqual(expected.InterestRate, actual.InterestRate, nameof(Share.InterestRate));
        }

        [TestCaseSource(nameof(_onlyShare))]
        public void CanDeserializeShareSettlementPercentage(Share expected, Share actual)
        {
            Assert.AreEqual(expected.SettlementPercentage, actual.SettlementPercentage, nameof(Share.SettlementPercentage));
        }

        [TestCaseSource(nameof(_onlyShare))]
        public void CanDeserializeShareIndPrice(Share expected, Share actual)
        {
            Assert.AreEqual(expected.IndPrice, actual.IndPrice, nameof(Share.IndPrice));
        }

        [TestCaseSource(nameof(_onlyShare))]
        public void CanDeserializeShareIndPriceAt(Share expected, Share actual)
        {
            Assert.AreEqual(expected.IndPriceAt, actual.IndPriceAt, nameof(Share.IndPriceAt));
        }

        [TestCaseSource(nameof(_onlyShare))]
        public void CanDeserializeShareAllTimeMin(Share expected, Share actual)
        {
            Assert.AreEqual(expected.AllTimeMin, actual.AllTimeMin, nameof(Share.AllTimeMin));
        }

        [TestCaseSource(nameof(_onlyShare))]
        public void CanDeserializeShareAllTimeMax(Share expected, Share actual)
        {
            Assert.AreEqual(expected.AllTimeMax, actual.AllTimeMax, nameof(Share.AllTimeMax));
        }

        [TestCaseSource(nameof(_onlyShare))]
        public void CanDeserializeShareAverage(Share expected, Share actual)
        {
            Assert.AreEqual(expected.Average, actual.Average, nameof(Share.Average));
        }

        [TestCaseSource(nameof(_onlyShare))]
        public void CanDeserializeShareSymbol(Share expected, Share actual)
        {
            Assert.AreEqual(expected.Symbol, actual.Symbol, nameof(Share.Symbol));
        }

        [TestCaseSource(nameof(_onlyShare))]
        public void CanDeserializeShareFaceValue(Share expected, Share actual)
        {
            Assert.AreEqual(expected.FaceValue, actual.FaceValue, nameof(Share.FaceValue));
        }

        [TestCaseSource(nameof(_onlyShare))]
        public void CanDeserializeShareFaceValueCurrency(Share expected, Share actual)
        {
            Assert.AreEqual(expected.FaceValueCurrency, actual.FaceValueCurrency, nameof(Share.FaceValueCurrency));
        }

        [TestCaseSource(nameof(_onlyShare))]
        public void CanDeserializeShareCategory(Share expected, Share actual)
        {
            Assert.AreEqual(expected.Category, actual.Category, nameof(Share.Category));
        }

        [TestCaseSource(nameof(_onlyShare))]
        public void CanDeserializeShareExpireAt(Share expected, Share actual)
        {
            Assert.AreEqual(expected.ExpireAt, actual.ExpireAt, nameof(Share.ExpireAt));
        }

        [TestCaseSource(nameof(_onlyShare))]
        public void CanDeserializeShareIsActive(Share expected, Share actual)
        {
            Assert.AreEqual(expected.IsActive, actual.IsActive, nameof(Share.IsActive));
        }

        [TestCaseSource(nameof(_onlyShare))]
        public void CanDeserializeShareLastDate(Share expected, Share actual)
        {
            Assert.AreEqual(expected.LastDate, actual.LastDate, nameof(Share.LastDate));
        }

        [TestCaseSource(nameof(_onlyShare))]
        public void CanDeserializeShareLastHtmlDate(Share expected, Share actual)
        {
            Assert.AreEqual(expected.LastHtmlDate, actual.LastHtmlDate, nameof(Share.LastHtmlDate));
        }

        [TestCaseSource(nameof(_onlyShare))]
        public void CanDeserializeShareCloseDate(Share expected, Share actual)
        {
            Assert.AreEqual(expected.CloseDate, actual.CloseDate, nameof(Share.CloseDate));
        }

        private static void GetDataFrom(string fileName, out ForeignCurrency actual)
        {
            var endPoint = BuildEndPoint(fileName);

            actual = endPoint.Get(new ForeignCurrencyType("dummy-data"));
        }

        private static void GetDataFrom(string fileName, out Share actual)
        {
            var endPoint = BuildEndPoint(fileName);

            actual = endPoint.Get(new ShareType("dummy-data"));
        }

        private static StockMarketEndPoint BuildEndPoint(string fileName)
        {
            var webClient = new FakeWebClient();

            string sourceCode = System.IO.File.ReadAllText($"StaticResources\\Stocks\\{fileName}.html");

            webClient.SetServerResponse(sourceCode);

            return new StockMarketEndPoint(webClient);
        }
    }
}
