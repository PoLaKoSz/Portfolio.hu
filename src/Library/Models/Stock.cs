using System;
using System.Collections.Generic;
using System.Linq;

namespace PoLaKoSz.Portfolio.Models
{
    public class Stock : IEquatable<Stock>
    {
        public Stock(
            bool isStarted,
            string tickerID,
            string ticker,
            int type,
            string fullName,
            string prefix,
            string currency,
            string isin,
            string name,
            string shortName,
            string chartName,
            int decimals,
            int forgDecimals,
            double open,
            double close,
            double last,
            string lastHTML,
            int lastSize,
            DateTime lastTime,
            DateTime lastHtmlTime,
            double change,
            double changePercentage,
            double min,
            double max,
            double bid,  // vételi árfolyam
            int bidSize, // kum db/db
            int bidNum,  // ajánlat db
            int bidComp, // ajánlat fő?
            double ask,  // eladási árfolyam
            int askSize, // kum db/db
            int askNum,  // ajánlat db
            int askComp, // ajánlat fő?
            int bid5,
            DateTime bid5Date,
            int bid5Size,
            int bid5Num,
            int bid5Comp,
            int ask5,
            DateTime ask5Date,
            int ask5Size,
            int ask5Num,
            int ask5Comp,
            int dealsCount,
            List<StockDeal> deals,
            double traffic,
            int trafficCount,
            double openInterest,
            int status,
            int panelJS,
            int id,
            int realTime,
            int pe2000,
            int pe2001,
            double closeOneMonth,
            TimeSpan closeOneMonthInterval,
            double closeThreeMonth,
            TimeSpan closeThreeMonthInterval,
            double closeOneYear,
            TimeSpan closeOneYearInterval,
            double oneMonthVolatility,
            double threeMonthVolatility,
            double oneYearVolatility,
            double eps2000,
            double eps2001,
            double minOneYear,
            DateTime minOneYearAt,
            double maxOneYear,
            DateTime maxOneYearAt,
            double minAllTimeValue,
            DateTime minAllTimeAt,
            double maxAllTimeValue,
            DateTime maxAllTimeAt,
            double closeMinOneYear,
            DateTime closeMinOneYearAt,
            double closeMaxOneYear,
            DateTime closeMaxOneYearAt,
            double closeMinAllTimeValue,
            DateTime closeMinAllTimeAt,
            double closeMaxAllTimeValue,
            DateTime closeMaxAllTimeAt,
            double trafficAvgInSixMonth,
            double trafficAvgInOneYear,
            int startCount,
            double kapit,
            double buxKapit,
            double changeInOneMonth,
            double changeInThreeMonth,
            double changeInOneYear,
            double startPrice,
            double minInOneYear,
            double maxInOneYear,
            ChartData imageData)
        {
            IsStarted = isStarted;
            TickerID = tickerID;
            Ticker = ticker;
            Type = type;
            FullName = fullName;
            Prefix = prefix;
            Currency = currency;
            ISIN = isin;
            Name = name;
            ShortName = shortName;
            ChartName = chartName;
            Decimals = decimals;
            ForgDecimals = forgDecimals;
            Open = open;
            Close = close;
            Last = last;
            LastHTML = lastHTML;
            LastSize = lastSize;
            LastTime = lastTime;
            LastHtmlTime = lastHtmlTime;
            Change = change;
            ChangePercentage = changePercentage;
            Min = min;
            Max = max;
            Bid = bid;
            BidSize = bidSize;
            BidNum = bidNum;
            BidComp = bidComp;
            Ask = ask;
            AskSize = askSize;
            AskNum = askNum;
            AskComp = askComp;
            Bid5 = bid5;
            Bid5Date = bid5Date;
            Bid5Size = bid5Size;
            Bid5Num = bid5Num;
            Bid5Comp = bid5Comp;
            Ask5 = ask5;
            Ask5Date = ask5Date;
            Ask5Size = ask5Size;
            Ask5Num = ask5Num;
            Ask5Comp = ask5Comp;
            DealsCount = dealsCount;
            Deals = deals;
            Traffic = traffic;
            TrafficCount = trafficCount;
            OpenInterest = openInterest;
            Status = status;
            PanelJS = panelJS;
            ID = id;
            RealTime = realTime;
            Pe2000 = pe2000;
            Pe2001 = pe2001;
            CloseOneMonth = closeOneMonth;
            CloseOneMonthInterval = closeOneMonthInterval;
            CloseThreeMonth = closeThreeMonth;
            CloseThreeMonthInterval = closeThreeMonthInterval;
            CloseOneYear = closeOneYear;
            CloseOneYearInterval = closeOneYearInterval;
            OneMonthVolatility = oneMonthVolatility;
            ThreeMonthVolatility = threeMonthVolatility;
            OneYearVolatility = oneYearVolatility;
            Eps2000 = eps2000;
            Eps2001 = eps2001;
            MinOneYear = minOneYear;
            MinOneYearAt = minOneYearAt;
            MaxOneYear = maxOneYear;
            MaxOneYearAt = maxOneYearAt;
            MinOfAllTime = minAllTimeValue;
            MinOfAllTimeAt = minAllTimeAt;
            MaxOfAllTime = maxAllTimeValue;
            MaxOfAllTimeAt = maxAllTimeAt;
            CloseMinOneYear = closeMinOneYear;
            CloseMinOneYearAt = closeMinOneYearAt;
            CloseMaxOneYear = closeMaxOneYear;
            CloseMaxOneYearAt = closeMaxOneYearAt;
            CloseMinAllTime = closeMinAllTimeValue;
            CloseMinAllTimeAt = closeMinAllTimeAt;
            CloseMaxOfAllTime = closeMaxAllTimeValue;
            CloseMaxAllTimeAt = closeMaxAllTimeAt;
            TrafficAvgInSixMonth = trafficAvgInSixMonth;
            TrafficAvgInOneYear = trafficAvgInOneYear;
            StartCount = startCount;
            Kapit = kapit;
            BuxKapit = buxKapit;
            ChangeInOneMonth = changeInOneMonth;
            ChangeInThreeMonth = changeInThreeMonth;
            ChangeInOneYear = changeInOneYear;
            StartPrice = startPrice;
            MinInOneYear = minInOneYear;
            MaxInOneYear = maxInOneYear;
            ImageData = imageData;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Stock"/> class.
        /// </summary>
        /// <param name="stock">Shallow copied non null object.</param>
        protected Stock(Stock stock)
            : this(
                  stock.IsStarted,
                  stock.TickerID,
                  stock.Ticker,
                  stock.Type,
                  stock.FullName,
                  stock.Prefix,
                  stock.Currency,
                  stock.ISIN,
                  stock.Name,
                  stock.ShortName,
                  stock.ChartName,
                  stock.Decimals,
                  stock.ForgDecimals,
                  stock.Open,
                  stock.Close,
                  stock.Last,
                  stock.LastHTML,
                  stock.LastSize,
                  stock.LastTime,
                  stock.LastHtmlTime,
                  stock.Change,
                  stock.ChangePercentage,
                  stock.Min,
                  stock.Max,
                  stock.Bid,
                  stock.BidSize,
                  stock.BidNum,
                  stock.BidComp,
                  stock.Ask,
                  stock.AskSize,
                  stock.AskNum,
                  stock.AskComp,
                  stock.Bid5,
                  stock.Bid5Date,
                  stock.Bid5Size,
                  stock.Bid5Num,
                  stock.Bid5Comp,
                  stock.Ask5,
                  stock.Ask5Date,
                  stock.Ask5Size,
                  stock.Ask5Num,
                  stock.Ask5Comp,
                  stock.DealsCount,
                  stock.Deals,
                  stock.Traffic,
                  stock.TrafficCount,
                  stock.OpenInterest,
                  stock.Status,
                  stock.PanelJS,
                  stock.ID,
                  stock.RealTime,
                  stock.Pe2000,
                  stock.Pe2001,
                  stock.CloseOneMonth,
                  stock.CloseOneMonthInterval,
                  stock.CloseThreeMonth,
                  stock.CloseThreeMonthInterval,
                  stock.CloseOneYear,
                  stock.CloseOneYearInterval,
                  stock.OneMonthVolatility,
                  stock.ThreeMonthVolatility,
                  stock.OneYearVolatility,
                  stock.Eps2000,
                  stock.Eps2001,
                  stock.MinOneYear,
                  stock.MinOneYearAt,
                  stock.MaxOneYear,
                  stock.MaxOneYearAt,
                  stock.MinOfAllTime,
                  stock.MinOfAllTimeAt,
                  stock.MaxOfAllTime,
                  stock.MaxOfAllTimeAt,
                  stock.CloseMinOneYear,
                  stock.CloseMinOneYearAt,
                  stock.CloseMaxOneYear,
                  stock.CloseMaxOneYearAt,
                  stock.CloseMinAllTime,
                  stock.CloseMinAllTimeAt,
                  stock.CloseMaxOfAllTime,
                  stock.CloseMaxAllTimeAt,
                  stock.TrafficAvgInSixMonth,
                  stock.TrafficAvgInOneYear,
                  stock.StartCount,
                  stock.Kapit,
                  stock.BuxKapit,
                  stock.ChangeInOneMonth,
                  stock.ChangeInThreeMonth,
                  stock.ChangeInOneYear,
                  stock.StartPrice,
                  stock.MinInOneYear,
                  stock.MaxInOneYear,
                  stock.ImageData)
        {
        }

        public bool IsStarted { get; }

        public string TickerID { get; }

        public string Ticker { get; }

        public int Type { get; }

        public string FullName { get; }

        public string Prefix { get; }

        public string Currency { get; }

        public string ISIN { get; }

        public string Name { get; }

        public string ShortName { get; }

        public string ChartName { get; }

        public int Decimals { get; }

        public int ForgDecimals { get; }

        public double Open { get; }

        public double Close { get; }

        public double Last { get; }

        public string LastHTML { get; }

        public int LastSize { get; }

        public DateTime LastTime { get; }

        public DateTime LastHtmlTime { get; }

        public double Change { get; }

        public double ChangePercentage { get; }

        public double Min { get; }

        public double Max { get; }

        public double Bid { get; }

        public int BidSize { get; }

        public int BidNum { get; }

        public int BidComp { get; }

        public double Ask { get; }

        public int AskSize { get; }

        public int AskNum { get; }

        public int AskComp { get; }

        public int Bid5 { get; }

        public DateTime Bid5Date { get; }

        public int Bid5Size { get; }

        public int Bid5Num { get; }

        public int Bid5Comp { get; }

        public int Ask5 { get; }

        public DateTime Ask5Date { get; }

        public int Ask5Size { get; }

        public int Ask5Num { get; }

        public int Ask5Comp { get; }

        public int DealsCount { get; }

        public List<StockDeal> Deals { get; }

        public double Traffic { get; }

        public int TrafficCount { get; }

        public double OpenInterest { get; }

        public int Status { get; }

        public int PanelJS { get; }

        public int ID { get; }

        public int RealTime { get; }

        public int Pe2000 { get; }

        public int Pe2001 { get; }

        public double CloseOneMonth { get; }

        public TimeSpan CloseOneMonthInterval { get; }

        public double CloseThreeMonth { get; }

        public TimeSpan CloseThreeMonthInterval { get; }

        public double CloseOneYear { get; }

        public TimeSpan CloseOneYearInterval { get; }

        public double OneMonthVolatility { get; }

        public double ThreeMonthVolatility { get; }

        public double OneYearVolatility { get; }

        public double Eps2000 { get; }

        public double Eps2001 { get; }

        public double MinOneYear { get; }

        public DateTime MinOneYearAt { get; }

        public double MaxOneYear { get; }

        public DateTime MaxOneYearAt { get; }

        public double MinOfAllTime { get; }

        public DateTime MinOfAllTimeAt { get; }

        public double MaxOfAllTime { get; }

        public DateTime MaxOfAllTimeAt { get; }

        public double CloseMinOneYear { get; }

        public DateTime CloseMinOneYearAt { get; }

        public double CloseMaxOneYear { get; }

        public DateTime CloseMaxOneYearAt { get; }

        public double CloseMinAllTime { get; }

        public DateTime CloseMinAllTimeAt { get; }

        public double CloseMaxOfAllTime { get; }

        public DateTime CloseMaxAllTimeAt { get; }

        public double TrafficAvgInSixMonth { get; }

        public double TrafficAvgInOneYear { get; }

        public int StartCount { get; }

        public double Kapit { get; }

        public double BuxKapit { get; }

        public double ChangeInOneMonth { get; }

        public double ChangeInThreeMonth { get; }

        public double ChangeInOneYear { get; }

        public double StartPrice { get; }

        public double MinInOneYear { get; }

        public double MaxInOneYear { get; }

        public ChartData ImageData { get; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Stock);
        }

        public bool Equals(Stock other)
        {
            return other != null &&
                   IsStarted == other.IsStarted &&
                   TickerID == other.TickerID &&
                   Ticker == other.Ticker &&
                   Type == other.Type &&
                   FullName == other.FullName &&
                   Prefix == other.Prefix &&
                   Currency == other.Currency &&
                   ISIN == other.ISIN &&
                   Name == other.Name &&
                   ShortName == other.ShortName &&
                   ChartName == other.ChartName &&
                   Decimals == other.Decimals &&
                   ForgDecimals == other.ForgDecimals &&
                   Open == other.Open &&
                   Close == other.Close &&
                   Last == other.Last &&
                   LastHTML == other.LastHTML &&
                   LastSize == other.LastSize &&
                   LastTime == other.LastTime &&
                   LastHtmlTime == other.LastHtmlTime &&
                   Change == other.Change &&
                   ChangePercentage == other.ChangePercentage &&
                   Min == other.Min &&
                   Max == other.Max &&
                   DealsCount == other.DealsCount &&
                   Deals.SequenceEqual(other.Deals) &&
                   Traffic == other.Traffic &&
                   TrafficCount == other.TrafficCount &&
                   OpenInterest == other.OpenInterest &&
                   Status == other.Status &&
                   PanelJS == other.PanelJS &&
                   ID == other.ID &&
                   RealTime == other.RealTime &&
                   Pe2000 == other.Pe2000 &&
                   Pe2001 == other.Pe2001 &&
                   CloseOneMonth == other.CloseOneMonth &&
                   CloseOneMonthInterval.Equals(other.CloseOneMonthInterval) &&
                   CloseThreeMonth == other.CloseThreeMonth &&
                   CloseThreeMonthInterval.Equals(other.CloseThreeMonthInterval) &&
                   CloseOneYear == other.CloseOneYear &&
                   CloseOneYearInterval.Equals(other.CloseOneYearInterval) &&
                   OneMonthVolatility == other.OneMonthVolatility &&
                   ThreeMonthVolatility == other.ThreeMonthVolatility &&
                   OneYearVolatility == other.OneYearVolatility &&
                   Eps2000 == other.Eps2000 &&
                   Eps2001 == other.Eps2001 &&
                   MinOneYear == other.MinOneYear &&
                   MinOneYearAt == other.MinOneYearAt &&
                   MaxOneYear == other.MaxOneYear &&
                   MaxOneYearAt == other.MaxOneYearAt &&
                   MinOfAllTime == other.MinOfAllTime &&
                   MinOfAllTimeAt == other.MinOfAllTimeAt &&
                   MaxOfAllTime == other.MaxOfAllTime &&
                   MaxOfAllTimeAt == other.MaxOfAllTimeAt &&
                   CloseMinOneYear == other.CloseMinOneYear &&
                   CloseMinOneYearAt == other.CloseMinOneYearAt &&
                   CloseMaxOneYear == other.CloseMaxOneYear &&
                   CloseMaxOneYearAt == other.CloseMaxOneYearAt &&
                   CloseMinAllTime == other.CloseMinAllTime &&
                   CloseMinAllTimeAt == other.CloseMinAllTimeAt &&
                   CloseMaxOfAllTime == other.CloseMaxOfAllTime &&
                   CloseMaxAllTimeAt == other.CloseMaxAllTimeAt &&
                   TrafficAvgInSixMonth == other.TrafficAvgInSixMonth &&
                   TrafficAvgInOneYear == other.TrafficAvgInOneYear &&
                   StartCount == other.StartCount &&
                   Kapit == other.Kapit &&
                   BuxKapit == other.BuxKapit &&
                   ChangeInOneMonth == other.ChangeInOneMonth &&
                   ChangeInThreeMonth == other.ChangeInThreeMonth &&
                   ChangeInOneYear == other.ChangeInOneYear &&
                   StartPrice == other.StartPrice &&
                   MinInOneYear == other.MinInOneYear &&
                   MaxInOneYear == other.MaxInOneYear &&
                   ImageData == other.ImageData;
        }

        public override int GetHashCode()
        {
            var hashCode = -1519320215;
            hashCode = (hashCode * -1521134295) + IsStarted.GetHashCode();
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(TickerID);
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(Ticker);
            hashCode = (hashCode * -1521134295) + Type.GetHashCode();
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(FullName);
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(Prefix);
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(Currency);
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(ISIN);
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(ShortName);
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(ChartName);
            hashCode = (hashCode * -1521134295) + Decimals.GetHashCode();
            hashCode = (hashCode * -1521134295) + ForgDecimals.GetHashCode();
            hashCode = (hashCode * -1521134295) + Open.GetHashCode();
            hashCode = (hashCode * -1521134295) + Close.GetHashCode();
            hashCode = (hashCode * -1521134295) + Last.GetHashCode();
            hashCode = (hashCode * -1521134295) + LastHTML.GetHashCode();
            hashCode = (hashCode * -1521134295) + LastSize.GetHashCode();
            hashCode = (hashCode * -1521134295) + LastTime.GetHashCode();
            hashCode = (hashCode * -1521134295) + LastHtmlTime.GetHashCode();
            hashCode = (hashCode * -1521134295) + Change.GetHashCode();
            hashCode = (hashCode * -1521134295) + ChangePercentage.GetHashCode();
            hashCode = (hashCode * -1521134295) + Min.GetHashCode();
            hashCode = (hashCode * -1521134295) + Max.GetHashCode();
            hashCode = (hashCode * -1521134295) + DealsCount.GetHashCode();
            hashCode = (hashCode * -1521134295) + EqualityComparer<List<StockDeal>>.Default.GetHashCode(Deals);
            hashCode = (hashCode * -1521134295) + Traffic.GetHashCode();
            hashCode = (hashCode * -1521134295) + TrafficCount.GetHashCode();
            hashCode = (hashCode * -1521134295) + OpenInterest.GetHashCode();
            hashCode = (hashCode * -1521134295) + Status.GetHashCode();
            hashCode = (hashCode * -1521134295) + PanelJS.GetHashCode();
            hashCode = (hashCode * -1521134295) + ID.GetHashCode();
            hashCode = (hashCode * -1521134295) + RealTime.GetHashCode();
            hashCode = (hashCode * -1521134295) + Pe2000.GetHashCode();
            hashCode = (hashCode * -1521134295) + Pe2001.GetHashCode();
            hashCode = (hashCode * -1521134295) + CloseOneMonth.GetHashCode();
            hashCode = (hashCode * -1521134295) + EqualityComparer<TimeSpan>.Default.GetHashCode(CloseOneMonthInterval);
            hashCode = (hashCode * -1521134295) + CloseThreeMonth.GetHashCode();
            hashCode = (hashCode * -1521134295) + EqualityComparer<TimeSpan>.Default.GetHashCode(CloseThreeMonthInterval);
            hashCode = (hashCode * -1521134295) + CloseOneYear.GetHashCode();
            hashCode = (hashCode * -1521134295) + EqualityComparer<TimeSpan>.Default.GetHashCode(CloseOneYearInterval);
            hashCode = (hashCode * -1521134295) + OneMonthVolatility.GetHashCode();
            hashCode = (hashCode * -1521134295) + ThreeMonthVolatility.GetHashCode();
            hashCode = (hashCode * -1521134295) + OneYearVolatility.GetHashCode();
            hashCode = (hashCode * -1521134295) + Eps2000.GetHashCode();
            hashCode = (hashCode * -1521134295) + Eps2001.GetHashCode();
            hashCode = (hashCode * -1521134295) + MinOneYear.GetHashCode();
            hashCode = (hashCode * -1521134295) + MinOneYearAt.GetHashCode();
            hashCode = (hashCode * -1521134295) + MaxOneYear.GetHashCode();
            hashCode = (hashCode * -1521134295) + MaxOneYearAt.GetHashCode();
            hashCode = (hashCode * -1521134295) + MinOfAllTime.GetHashCode();
            hashCode = (hashCode * -1521134295) + MinOfAllTimeAt.GetHashCode();
            hashCode = (hashCode * -1521134295) + MaxOfAllTime.GetHashCode();
            hashCode = (hashCode * -1521134295) + MaxOfAllTimeAt.GetHashCode();
            hashCode = (hashCode * -1521134295) + CloseMinOneYear.GetHashCode();
            hashCode = (hashCode * -1521134295) + CloseMinOneYearAt.GetHashCode();
            hashCode = (hashCode * -1521134295) + CloseMaxOneYear.GetHashCode();
            hashCode = (hashCode * -1521134295) + CloseMaxOneYearAt.GetHashCode();
            hashCode = (hashCode * -1521134295) + CloseMinAllTime.GetHashCode();
            hashCode = (hashCode * -1521134295) + CloseMinAllTimeAt.GetHashCode();
            hashCode = (hashCode * -1521134295) + CloseMaxOfAllTime.GetHashCode();
            hashCode = (hashCode * -1521134295) + CloseMaxAllTimeAt.GetHashCode();
            hashCode = (hashCode * -1521134295) + TrafficAvgInSixMonth.GetHashCode();
            hashCode = (hashCode * -1521134295) + TrafficAvgInOneYear.GetHashCode();
            hashCode = (hashCode * -1521134295) + StartCount.GetHashCode();
            hashCode = (hashCode * -1521134295) + Kapit.GetHashCode();
            hashCode = (hashCode * -1521134295) + BuxKapit.GetHashCode();
            hashCode = (hashCode * -1521134295) + ChangeInOneMonth.GetHashCode();
            hashCode = (hashCode * -1521134295) + ChangeInThreeMonth.GetHashCode();
            hashCode = (hashCode * -1521134295) + ChangeInOneYear.GetHashCode();
            hashCode = (hashCode * -1521134295) + StartPrice.GetHashCode();
            hashCode = (hashCode * -1521134295) + MinInOneYear.GetHashCode();
            hashCode = (hashCode * -1521134295) + MaxInOneYear.GetHashCode();
            hashCode = (hashCode * -1521134295) + EqualityComparer<ChartData>.Default.GetHashCode(ImageData);
            return hashCode;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
