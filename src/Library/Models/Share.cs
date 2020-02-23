using System;

namespace PoLaKoSz.Portfolio.Models
{
    public class Share : Stock
    {
        public Share(
            Stock stock,
            string subGroup,
            TimeSpan openTime,
            TimeSpan closeTime,
            int market,
            string board,
            double d,
            double suly,
            double dBumix,
            double sulyBumix,
            int movingCount,
            int expire,
            double interestRate,
            double settlementPercentage,
            double indPrice,
            DateTime indPriceAt,
            double allTimeMin,
            double allTimeMax,
            double average,
            string symbol,
            double faceValue,
            string faceValueCurrency,
            string category,
            string expireAt,
            bool isActive,
            string lastDate,
            string lastHtmlDate,
            string closeDate)
            : base(stock)
        {
            SubGroup = subGroup;
            OpenTime = openTime;
            CloseTime = closeTime;
            Market = market;
            Board = board;
            D = d;
            Suly = suly;
            DBumix = dBumix;
            SulyBumix = sulyBumix;
            MovingCount = movingCount;
            Expire = expire;
            InterestRate = interestRate;
            SettlementPercentage = settlementPercentage;
            IndPrice = indPrice;
            IndPriceAt = indPriceAt;
            AllTimeMin = allTimeMin;
            AllTimeMax = allTimeMax;
            Average = average;
            Symbol = symbol;
            FaceValue = faceValue;
            FaceValueCurrency = faceValueCurrency;
            Category = category;
            ExpireAt = expireAt;
            IsActive = isActive;
            LastDate = lastDate;
            LastHtmlDate = lastHtmlDate;
            CloseDate = closeDate;
        }

        public string SubGroup { get; }

        public TimeSpan OpenTime { get; }

        public TimeSpan CloseTime { get; }

        public int Market { get; }

        public string Board { get; }

        public double D { get; }

        public double Suly { get; }

        public double DBumix { get; }

        public double SulyBumix { get; }

        public int MovingCount { get; }

        public int Expire { get; }

        public double InterestRate { get; }

        public double SettlementPercentage { get; }

        public double IndPrice { get; }

        public DateTime IndPriceAt { get; }

        public double AllTimeMin { get; }

        public double AllTimeMax { get; }

        public double Average { get; }

        public string Symbol { get; }

        public double FaceValue { get; }

        public string FaceValueCurrency { get; }

        public string Category { get; }

        public string ExpireAt { get; }

        public bool IsActive { get; }

        public string LastDate { get; }

        public string LastHtmlDate { get; }

        public string CloseDate { get; }
    }
}
