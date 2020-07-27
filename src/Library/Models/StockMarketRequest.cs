namespace PoLaKoSz.Portfolio.Models
{
    public class StockMarketRequest<T>
        where T : StockType
    {
        public StockMarketRequest()
        {
            LastDay();
        }

        internal string Interval { get; private set; }

        internal string TickerName { get; private set; }

        public StockMarketRequest<T> LastDay()
        {
            Interval = "1D";
            return this;
        }

        public StockMarketRequest<T> LastMonth()
        {
            Interval = "1M";
            return this;
        }

        public StockMarketRequest<T> LastThreeMonth()
        {
            Interval = "3M";
            return this;
        }

        public StockMarketRequest<T> LastSixMonth()
        {
            Interval = "6M";
            return this;
        }

        public StockMarketRequest<T> LastYear()
        {
            Interval = "1Y";
            return this;
        }

        public StockMarketRequest<T> LastFiveYear()
        {
            Interval = "5Y";
            return this;
        }

        public StockMarketRequest<T> For(T stockType)
        {
            return For(stockType.Name);
        }

        public StockMarketRequest<T> For(string tickerName)
        {
            TickerName = tickerName;
            return this;
        }
    }
}
