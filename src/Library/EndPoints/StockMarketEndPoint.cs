using System.Net.Http;
using PoLaKoSz.Portfolio.Deserializers;
using PoLaKoSz.Portfolio.Models;

namespace PoLaKoSz.Portfolio.EndPoints
{
    internal class StockMarketEndPoint : IStockMarketEndPoint
    {
        private readonly HttpClient _httpClient;
        private readonly StockApiDeserializer parser;

        internal StockMarketEndPoint(HttpClient httpClient)
        {
            _httpClient = httpClient;
            parser = new StockApiDeserializer();
        }

        public StockRequest<ForeignCurrency> Get(ForeignCurrencyType ticker)
        {
            return new StockRequest<ForeignCurrency>(
                ticker,
                _httpClient,
                (input) => parser.ParseAsForeignCurrency(input));
        }

        public StockRequest<Share> Get(ShareType ticker)
        {
            return new StockRequest<Share>(
                ticker,
                _httpClient,
                (input) => parser.ParseAsShare(input));
        }
    }
}
