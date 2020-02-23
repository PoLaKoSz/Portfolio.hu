using System;
using System.Collections.Generic;
using System.Linq;

namespace PoLaKoSz.Portfolio.Models
{
    public class ChartData : IEquatable<ChartData>
    {
        public ChartData(DateTime? startTime, DateTime? endTime, List<StockPrice> prices, string dateFormat)
        {
            StartTime = startTime;
            EndTime = endTime;
            Prices = prices;
            DateFormat = dateFormat;
        }

        public DateTime? StartTime { get; }

        public DateTime? EndTime { get; }

        public List<StockPrice> Prices { get; }

        public string DateFormat { get; }

        public override bool Equals(object obj)
        {
            return Equals(obj as ChartData);
        }

        public bool Equals(ChartData other)
        {
            return other != null &&
                   StartTime == other.StartTime &&
                   EndTime == other.EndTime &&
                   Prices.SequenceEqual(other.Prices) &&
                   DateFormat == other.DateFormat;
        }

        public override int GetHashCode()
        {
            var hashCode = -777482270;
            hashCode = (hashCode * -1521134295) + StartTime.GetHashCode();
            hashCode = (hashCode * -1521134295) + EndTime.GetHashCode();
            hashCode = (hashCode * -1521134295) + EqualityComparer<List<StockPrice>>.Default.GetHashCode(Prices);
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(DateFormat);
            return hashCode;
        }
    }
}
