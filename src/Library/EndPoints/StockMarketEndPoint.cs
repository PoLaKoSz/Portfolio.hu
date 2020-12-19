using System.Net.Http;
using PoLaKoSz.Portfolio.Models;

namespace PoLaKoSz.Portfolio.EndPoints
{
    internal class StockMarketEndPoint : IStockMarketEndPoint
    {
        private readonly HttpClient _httpClient;

        internal StockMarketEndPoint(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public StockRequest<ForeignCurrency> Get(ForeignCurrencyType ticker)
        {
            return new StockRequest<ForeignCurrency>(ticker, _httpClient);
        }

        public StockRequest<Share> Get(ShareType ticker)
        {
            return new StockRequest<Share>(ticker, _httpClient);
        }
    }
}
