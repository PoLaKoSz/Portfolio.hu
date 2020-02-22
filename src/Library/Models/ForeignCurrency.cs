using System;
using System.Collections.Generic;

namespace PoLaKoSz.hu.Portfolio_hu_API.Models
{
    public class ForeignCurrency : Stock, IEquatable<ForeignCurrency>
    {
        public ForeignCurrency(
            Stock stock,
            int markersID,
            string marketCode,
            DateTime dataStart,
            DateTime dataEnd)
            : base(stock)
        {
            MarkersID = markersID;
            MarketCode = marketCode;
            DataStart = dataStart;
            DataEnd = dataEnd;
        }

        public int MarkersID { get; }

        public string MarketCode { get; }

        public DateTime DataStart { get; }

        public DateTime DataEnd { get; }

        public override bool Equals(object obj)
        {
            return Equals(obj as ForeignCurrency);
        }

        public bool Equals(ForeignCurrency other)
        {
            return other != null &&
                   base.Equals(other) &&
                   MarkersID == other.MarkersID &&
                   MarketCode == other.MarketCode &&
                   DataStart == other.DataStart &&
                   DataEnd == other.DataEnd &&
                   base.Equals(other);
        }

        public override int GetHashCode()
        {
            var hashCode = 1186860024;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + MarkersID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(MarketCode);
            hashCode = hashCode * -1521134295 + DataStart.GetHashCode();
            hashCode = hashCode * -1521134295 + DataEnd.GetHashCode();
            hashCode = hashCode * base.GetHashCode();
            return hashCode;
        }
    }
}
