using System;

namespace PoLaKoSz.hu.Portfolio_hu_API.Models
{
    public class Sale
    {
        public DateTime Time { get; internal set; }

        public double Price { get; internal set; }

        public float Change { get; internal set; }

        /// <value>-1 = down, 0 = steady, 1 = up</value>
        public int ChangeDirection { get; internal set; }

        public int Count { get; internal set; }

        public long Value { get; set; }
    }
}
