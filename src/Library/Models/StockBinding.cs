using System;

namespace PoLaKoSz.hu.Portfolio_hu_API.Models
{
    public class StockBinding
    {
        public StockBinding(DateTime date, double price, int cout)
        {
            At = date;
            Price = price;
            Cout = cout;
        }

        public DateTime At { get; }

        public double Price { get; }

        public int Cout { get; }
    }
}
