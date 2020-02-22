using System;

namespace PoLaKoSz.hu.Portfolio_hu_API.Models
{
    public class StockPrice : IEquatable<StockPrice>
    {
        public StockPrice(double value, DateTime at, int traffic)
        {
            Value = value;
            At = at;
            Traffic = traffic;
        }

        public double Value { get; }

        public DateTime At { get; }

        public double Traffic { get; }

        public override bool Equals(object obj)
        {
            return Equals(obj as StockPrice);
        }

        public bool Equals(StockPrice other)
        {
            return other != null &&
                   Value == other.Value &&
                   At == other.At &&
                   Traffic == other.Traffic;
        }

        public override int GetHashCode()
        {
            var hashCode = -1957751464;
            hashCode = hashCode * -1521134295 + Value.GetHashCode();
            hashCode = hashCode * -1521134295 + At.GetHashCode();
            hashCode = hashCode * -1521134295 + Traffic.GetHashCode();
            return hashCode;
        }
    }
}
