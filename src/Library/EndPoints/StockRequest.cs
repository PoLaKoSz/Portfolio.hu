using System;
using System.Net.Http;
using System.Threading.Tasks;
using PoLaKoSz.Portfolio.Models;

namespace PoLaKoSz.Portfolio.EndPoints
{
    public class StockRequest<T>
        where T : Stock
    {
        private static readonly string BASEURL;
        private readonly StockType ticker;
        private readonly HttpClient httpClient;
        private readonly Func<string, T> converter;

        static StockRequest()
        {
            BASEURL = "https://data.portfolio.hu/all/json/";
        }

        internal StockRequest(
            StockType ticker,
            HttpClient httpClient,
            Func<string, T> converter)
        {
            this.ticker = ticker;
            this.httpClient = httpClient;
            this.converter = converter;
        }

        public async Task<T> LastDay()
        {
            string json = await httpClient
                .GetStringAsync($"{BASEURL}{ticker.Name}:interval=1D")
                .ConfigureAwait(false);

            return converter.Invoke(json);
        }
    }
}
