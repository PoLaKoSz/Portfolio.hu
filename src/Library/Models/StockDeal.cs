using System;
using System.Collections.Generic;

namespace PoLaKoSz.hu.Portfolio_hu_API.Models
{
    public class StockDeal : IEquatable<StockDeal>
    {
        /// <summary>
        /// Initialize a new instance.
        /// </summary>
        /// <param name="at">UTC time when the successfull deal happend.</param>
        /// <param name="direction">The price direction compared to the previous deal.
        /// Could be -1, 0 or 1 depending on if the price went down, didn't move or went up.</param>
        /// <param name="unknown">This parameter purpose is currently unknown.</param>
        /// <param name="price">The current value of the stock when the deal was made.</param>
        /// <param name="percentage">There is no idea how this percentage calculated.</param>
        public StockDeal(int id, DateTime at, string direction, string unknown, double price, int count, double percentage)
        {
            ID = id;
            At = at;
            Direction = ConvertToInt(direction);
            Unknown = unknown ?? "";
            Price = price;
            Count = count;
            Percentage = percentage;
        }

        public int ID { get; }
        public DateTime At { get; }
        public int Direction { get; }
        public string Unknown { get; }
        public double Price { get; }
        public int Count { get; }
        public double Percentage { get; }

        public override bool Equals(object obj)
        {
            return Equals(obj as StockDeal);
        }

        public bool Equals(StockDeal other)
        {
            return other != null &&
                   ID == other.ID &&
                   At == other.At &&
                   Direction == other.Direction &&
                   Unknown == other.Unknown &&
                   Price == other.Price &&
                   Count == other.Count &&
                   Percentage == other.Percentage;
        }

        public override int GetHashCode()
        {
            var hashCode = -1397032362;
            hashCode = hashCode * -1521134295 + ID.GetHashCode();
            hashCode = hashCode * -1521134295 + At.GetHashCode();
            hashCode = hashCode * -1521134295 + Direction.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Unknown);
            hashCode = hashCode * -1521134295 + Price.GetHashCode();
            hashCode = hashCode * -1521134295 + Count.GetHashCode();
            hashCode = hashCode * -1521134295 + Percentage.GetHashCode();
            return hashCode;
        }

        private int ConvertToInt(string direction)
        {
            if (direction == "+")
                return 1;
            else if (direction == "" || direction == " ")
                return 0;
            else if (direction == "-")
                return -1;

            throw new ArgumentException($"Unknown StockDeal direction: {direction}", nameof(direction));
        }
    }
}
