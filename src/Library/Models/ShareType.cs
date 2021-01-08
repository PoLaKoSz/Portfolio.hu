using System;

namespace PoLaKoSz.hu.Portfolio_hu_API.Models
{
    public class ShareType : StockType, IEquatable<ShareType>
    {
        public ShareType(string ticker)
            : base(ticker) { }

        public bool Equals(ShareType other) => other.Name == this.Name;

        public override string ToString()
        {
            return $"ShareType {{ {nameof(Name)} = {Name} }}";
        }
    }
}
