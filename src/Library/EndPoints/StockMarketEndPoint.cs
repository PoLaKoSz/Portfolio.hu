using System;
using System.Net.Http;
using System.Threading.Tasks;
using PoLaKoSz.Portfolio.Deserializers;
using PoLaKoSz.Portfolio.Models;

namespace PoLaKoSz.Portfolio.EndPoints
{
    internal class StockMarketEndPoint : IStockMarketEndPoint
    {
        private static readonly StockApiDeserializer _parser;
        private static readonly string _baseURL;
        private readonly HttpClient _httpClient;

        static StockMarketEndPoint()
        {
            _parser = new StockApiDeserializer();
            _baseURL = "https://data.portfolio.hu/all/json/";
        }

        internal StockMarketEndPoint(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Share> GetShare(Func<StockMarketRequest<ShareType>, StockMarketRequest<ShareType>> request)
        {
            var requestBuilder = new StockMarketRequest<ShareType>();
            var stockType = request.Invoke(requestBuilder);

            string json = await _httpClient
                .GetStringAsync($"{_baseURL}{requestBuilder.TickerName}:interval={requestBuilder.Interval}")
                .ConfigureAwait(false);

            return _parser.Parse(requestBuilder, json);
        }

        public async Task<ForeignCurrency> GetForeignCurrency(Func<StockMarketRequest<ForeignCurrencyType>, StockMarketRequest<ForeignCurrencyType>> request)
        {
            var requestBuilder = new StockMarketRequest<ForeignCurrencyType>();
            var stockType = request.Invoke(requestBuilder);

            string json = await _httpClient
                .GetStringAsync($"{_baseURL}{requestBuilder.TickerName}:interval={requestBuilder.Interval}")
                .ConfigureAwait(false);

            System.IO.File.WriteAllText($"{requestBuilder.TickerName}.json", json);

            return _parser.Parse(requestBuilder, json);
        }
    }
}
