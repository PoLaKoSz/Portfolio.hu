using System.Net.Http;
using PoLaKoSz.Portfolio.EndPoints;

namespace PoLaKoSz.Portfolio
{
    public class Portfolio : IPortfolio
    {
        public Portfolio()
            : this(new HttpClient())
        {
        }

        public Portfolio(HttpClient httpClient)
        {
            this.StockMarket = new StockMarketEndPoint(httpClient);
        }

        public IStockMarketEndPoint StockMarket { get; }
    }
}
