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

        public async Task<Share> Get(ShareType stock)
        {
            string json = await _httpClient
                .GetStringAsync($"{_baseURL}{stock.Name}:interval=1D&resolution=600")
                .ConfigureAwait(false);

            return _parser.AsShare(json);
        }

        public async Task<ForeignCurrency> Get(ForeignCurrencyType stock)
        {
            string json = await _httpClient
                .GetStringAsync($"{_baseURL}{stock.Name}:interval=1D&resolution=600")
                .ConfigureAwait(false);

            return _parser.AsForex(json);
        }
    }
}
