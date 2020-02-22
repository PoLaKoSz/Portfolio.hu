using Newtonsoft.Json.Linq;
using PoLaKoSz.Portfolio.Exceptions;
using PoLaKoSz.Portfolio.Models;
using System;
using System.Collections.Generic;

namespace PoLaKoSz.Portfolio.Deserializers
{
    /// <summary>
    /// Fastest deserialization method which checks if
    /// a JSON string contains unparsed property.
    /// </summary>
    public class StockApiDeserializer : SafeJsonDeserializer
    {
        public ForeignCurrency AsForex(string json)
        {
            try
            {
                var jObject = JObject.Parse(json);

                var stock = ParseCommonProperties(jObject);

                int markersID = ToInt("markersid", jObject);
                string marketCode = ToString("marketcode", jObject);
                DateTime dataStart = FromUnixTimestamp("from", jObject);
                DateTime dataEnd = FromUnixTimestamp("to", jObject);

                base.CheckDeserializationSuccessfull(jObject);

                return new ForeignCurrency(stock, markersID, marketCode, dataStart, dataEnd);
            }
            catch (Exception ex)
            {
                throw new DeprecatedLibraryException($"Cannot deserialize JSON: >>{json}<<", ex);
            }
        }

        public Share AsShare(string json)
        {
            try
            {
                var jObject = JObject.Parse(json);

                var stock = ParseCommonProperties(jObject);

                if (stock.ImageData == null && stock.IsStarted)
                {
                    throw new FormatException("Stock.ImageData property is null but the trading with stock is already started!");
                }

                string subGroup = ToString("alcsoport", jObject);
                TimeSpan openTime = TimeSpan.Parse(ToString("opentime", jObject));
                TimeSpan closeTime = TimeSpan.Parse(ToString("closetime", jObject));
                int market = ToInt("piac", jObject);
                string board = ToString("board", jObject);
                double d = ToDouble("d", jObject);
                double suly = ToDouble("suly", jObject);
                double dBumix = ToDouble("d_bumix", jObject);
                double sulyBumix = ToDouble("suly_bumix", jObject);
                int movingCount = ToInt("mozgodb", jObject);
                int expire = ToInt("lejarat", jObject);
                double interestRate = ToDouble("kamattartalom", jObject);
                double settlementPercentage = ToDouble("settlementp", jObject);
                double indPrice = ToDouble("indprice", jObject);
                DateTime indPriceAt = FromUnixTimestamp("indpricetime", jObject);
                double allTimeMin = ToDouble("tortmin", jObject);
                double allTimeMax = ToDouble("tortmax", jObject);
                double average = ToDouble("avg", jObject);
                string symbol = ToString("symbol", jObject);
                double faceValue = ToDouble("facevalue", jObject);
                string faceValueCurrency = ToString("facevalue_currency", jObject);
                string category = ToString("category", jObject);
                string expireAt = ToString("expiry", jObject);
                bool isActive = ToBool("active", jObject);
                string lastDate = ToString("lastdatum", jObject);
                string lastHtmlDate = ToString("lasthtmldatum", jObject);
                string closeDate = ToString("closedatum", jObject);

                base.CheckDeserializationSuccessfull(jObject);

                return new Share(
                    stock,
                    subGroup,
                    openTime,
                    closeTime,
                    market,
                    board,
                    d,
                    suly,
                    dBumix,
                    sulyBumix,
                    movingCount,
                    expire,
                    interestRate,
                    settlementPercentage,
                    indPrice,
                    indPriceAt,
                    allTimeMin,
                    allTimeMax,
                    average,
                    symbol,
                    faceValue,
                    faceValueCurrency,
                    category,
                    expireAt,
                    isActive,
                    lastDate,
                    lastHtmlDate,
                    closeDate);
            }
            catch (Exception ex)
            {
                throw new DeprecatedLibraryException($"Cannot deserialize JSON: >>{json}<<", ex);
            }
        }

        private Stock ParseCommonProperties(JObject jObject)
        {
            bool isStarted = ToBool("started", jObject);
            var tickerID = ToString("tickerid", jObject);
            var ticker = ToString("ticker", jObject);
            var type = ToInt("type", jObject);
            var fullName = ToString("fname", jObject);
            var prefix = ToString("prefix", jObject);
            var currency = ToString("currency", jObject);
            var isin = ToString("isin", jObject);
            var name = ToString("name", jObject);
            var shortName = ToString("shortname", jObject);
            var chartName = ToString("chartname", jObject);
            var decimals = ToInt("decimals", jObject);
            var forgDecimals = ToInt("forgdecimals", jObject);
            var open = ToDouble("open", jObject);
            var close = ToDouble("close", jObject);
            var last = ToDouble("last", jObject);
            var lastHTML = ToString("lasthtml", jObject);
            var lastSize = ToInt("lastsize", jObject);
            DateTime lastTime = FromUnixTimestamp("lasttime", jObject);
            DateTime lastHtmlTime = FromUnixTimestamp("lasthtmltime", jObject);
            var change = ToDouble("chg", jObject);
            var changePercentage = ToDouble("chgpc", jObject);
            var min = ToDouble("min", jObject);
            var max = ToDouble("max", jObject);
            var bid = ToDouble("bid", jObject);
            var bidSize = ToInt("bid_size", jObject);
            var bidNum = ToInt("bid_num", jObject);
            var bidComp = ToInt("bid_comp", jObject);
            var ask = ToDouble("ask", jObject);
            var askSize = ToInt("ask_size", jObject);
            var askNum = ToInt("ask_num", jObject);
            var askComp = ToInt("ask_comp", jObject);
            var bid5 = FromUnnecessaryObject("bid5", jObject);
            DateTime bid5Date = FromUnixTimestamp("bid5_datum", jObject);
            var bid5Size = FromUnnecessaryObject("bid5_size", jObject);
            var bid5Num = FromUnnecessaryObject("bid5_num", jObject);
            var bid5Comp = FromUnnecessaryObject("bid5_comp", jObject);
            var ask5 = FromUnnecessaryObject("ask5", jObject);
            DateTime ask5Date = FromUnixTimestamp("ask5_datum", jObject);
            var ask5Size = FromUnnecessaryObject("ask5_size", jObject);
            var ask5Num = FromUnnecessaryObject("ask5_num", jObject);
            var ask5Comp = FromUnnecessaryObject("ask5_comp", jObject);
            var dealsCount = ToInt("kotesdb", jObject);
            List<StockDeal> deals = ToStockDealList("kotesek", jObject);
            var traffic = ToDouble("forgalom", jObject);
            var trafficCount = ToInt("forgalomdb", jObject);
            var openInterest = ToDouble("open_interest", jObject);
            var status = ToInt("status", jObject);
            var panelJS = ToInt("paneljs", jObject);
            var id = ToInt("id", jObject);
            var realTime = ToInt("realtime", jObject);
            var pe2000 = ToInt("pe2000", jObject);
            var pe2001 = ToInt("pe2001", jObject);
            var closeOneMonth = ToDouble("close1m", jObject);
            TimeSpan closeOneMonthInterval = AsDays("close1mtime", jObject);
            var closeThreeMonth = ToDouble("close3m", jObject);
            TimeSpan closeThreeMonthInterval = AsDays("close3mtime", jObject);
            var closeOneYear = ToDouble("close1y", jObject);
            TimeSpan closeOneYearInterval = AsDays("close1ytime", jObject);
            var oneMonthVolatility = ToDouble("vol1m", jObject);
            var threeMonthVolatility = ToDouble("vol3m", jObject);
            var oneYearVolatility = ToDouble("vol1y", jObject);
            var eps2000 = ToDouble("eps2000", jObject);
            var eps2001 = ToDouble("eps2001", jObject);
            var minOneYear = ToDouble("min1y", jObject);
            DateTime minOneYearAt = FromUnixTimestamp("min1ytime", jObject);
            var maxOneYear = ToDouble("max1y", jObject);
            DateTime maxOneYearAt = FromUnixTimestamp("max1ytime", jObject);
            var minAllTimeValue = ToDouble("minall", jObject);
            DateTime minAllTimeAt = FromUnixTimestamp("minalltime", jObject);
            var maxAllTimeValue = ToDouble("maxall", jObject);
            DateTime maxAllTimeAt = FromUnixTimestamp("maxalltime", jObject);
            var closeMinOneYear = ToDouble("closemin1y", jObject);
            DateTime closeMinOneYearAt = FromUnixTimestamp("closemin1ytime", jObject);
            var closeMaxOneYear = ToDouble("closemax1y", jObject);
            DateTime closeMaxOneYearAt = FromUnixTimestamp("closemax1ytime", jObject);
            var closeMinAllTimeValue = ToDouble("closeminall", jObject);
            DateTime closeMinAllTimeAt = FromUnixTimestamp("closeminalltime", jObject);
            var closeMaxAllTimeValue = ToDouble("closemaxall", jObject);
            DateTime closeMaxAllTimeAt = FromUnixTimestamp("closemaxalltime", jObject);
            var trafficAvgInSixMonth = ToDouble("forgavg6m", jObject);
            var trafficAvgInOneYear = ToDouble("forgavg1y", jObject);
            var startCount = ToInt("indulodb", jObject);
            var kapit = ToDouble("kapit", jObject);
            var buxKapit = ToDouble("buxkapit", jObject);
            var changeInOneMonth = ToDouble("chg1m", jObject);
            var changeInThreeMonth = ToDouble("chg3m", jObject);
            var changeInOneYear = ToDouble("chg1y", jObject);
            var startPrice = ToDouble("induloar", jObject);
            var minInOneYear = ToDouble("yearmin", jObject);
            var maxInOneYear = ToDouble("yearmax", jObject);
            ChartData imageData = ToChartData("imgdata", jObject);

            return new Stock(
                isStarted,
                tickerID,
                ticker,
                type,
                fullName,
                prefix,
                currency,
                isin,
                name,
                shortName,
                chartName,
                decimals,
                forgDecimals,
                open,
                close,
                last,
                lastHTML,
                lastSize,
                lastTime,
                lastHtmlTime,
                change,
                changePercentage,
                min,
                max,
                bid,
                bidSize,
                bidNum,
                bidComp,
                ask,
                askSize,
                askNum,
                askComp,
                bid5,
                bid5Date,
                bid5Size,
                bid5Num,
                bid5Comp,
                ask5,
                ask5Date,
                ask5Size,
                ask5Num,
                ask5Comp,
                dealsCount,
                deals,
                traffic,
                trafficCount,
                openInterest,
                status,
                panelJS,
                id,
                realTime,
                pe2000,
                pe2001,
                closeOneMonth,
                closeOneMonthInterval,
                closeThreeMonth,
                closeThreeMonthInterval,
                closeOneYear,
                closeOneYearInterval,
                oneMonthVolatility,
                threeMonthVolatility,
                oneYearVolatility,
                eps2000,
                eps2001,
                minOneYear,
                minOneYearAt,
                maxOneYear,
                maxOneYearAt,
                minAllTimeValue,
                minAllTimeAt,
                maxAllTimeValue,
                maxAllTimeAt,
                closeMinOneYear,
                closeMinOneYearAt,
                closeMaxOneYear,
                closeMaxOneYearAt,
                closeMinAllTimeValue,
                closeMinAllTimeAt,
                closeMaxAllTimeValue,
                closeMaxAllTimeAt,
                trafficAvgInSixMonth,
                trafficAvgInOneYear,
                startCount,
                kapit,
                buxKapit,
                changeInOneMonth,
                changeInThreeMonth,
                changeInOneYear,
                startPrice,
                minInOneYear,
                maxInOneYear,
                imageData);
        }

        private List<StockDeal> ToStockDealList(string propertyName, JObject jObject)
        {
            var list = new List<StockDeal>();

            var mainProperty = jObject.SelectToken(propertyName);

            foreach (JProperty jProperty in mainProperty.Children())
            {
                try
                {
                    list.Add(GetStockDeal(jProperty));
                }
                catch (Exception ex)
                {
                    throw new FormatException($"Cannot deserialize JProperty: {jProperty}", ex);
                }
            }

            Remove(propertyName, jObject);

            return list;
        }

        private StockDeal GetStockDeal(JProperty jProperty)
        {
            if (jProperty.Count != 1)
            {
                throw new FormatException("kotesID vagy valami nem található!");
            }

            var jContainer = (JArray)jProperty.First;
            if (jContainer.Count != 6)
            {
                throw new FormatException("Trade data must contain exactly 6 items!");
            }

            var id = Convert.ToInt32(jProperty.Name);
            var at = DateTimeOffset.FromUnixTimeSeconds((int)jContainer[0]).UtcDateTime;
            var direction = jContainer[1].ToString();
            var unknown = jContainer[2].ToString();
            var price = (double)jContainer[3];
            var count = (int)jContainer[4];
            var percentage = (double)jContainer[5];

            return new StockDeal(id, at, direction, unknown, price, count, percentage);
        }
        
        private ChartData ToChartData(string propertyName, JObject jObject)
        {
            JObject container = (JObject)jObject.SelectToken(propertyName);

            if (container == null)
            {
                return null;
            }

            DateTime startTime = FromUnixTimestamp("imgdatafrom", container);
            DateTime endTime = FromUnixTimestamp("imgdatato", container);
            List<StockPrice> prices = ToStockPrices("data", container);
            string dateFormat = ToString("imgdateformat", container);

            Remove(propertyName, jObject);

            return new ChartData(startTime, endTime, prices, dateFormat);
        }

        private List<StockPrice> ToStockPrices(string propertyName, JObject jObject)
        {
            var list = new List<StockPrice>();

            var container = jObject.SelectToken(propertyName);

            foreach (JObject node in container.Children())
            {
                try
                {
                    list.Add(GetStockPrice(node));
                }
                catch (Exception ex)
                {
                    throw new FormatException($"Cannot deserialize JProperty: {node}", ex);
                }
            }

            return list;
        }

        private StockPrice GetStockPrice(JObject jObject)
        {
            var value = ToDouble("price", jObject);
            var at = FromUnixTimestamp("date", jObject);
            var traffic = ToInt("volume", jObject);

            return new StockPrice(value, at, traffic);
        }
    }
}
