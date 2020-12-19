using System.Net.Http;
using System.Threading.Tasks;
using PoLaKoSz.Portfolio.Deserializers;
using PoLaKoSz.Portfolio.Models;

namespace PoLaKoSz.Portfolio.EndPoints
{
    public class StockRequest<T>
        where T : Stock
    {
        private static readonly StockApiDeserializer PARSER;
        private static readonly string BASEURL;
        private readonly StockType ticker;
        private readonly HttpClient httpClient;

        static StockRequest()
        {
            PARSER = new StockApiDeserializer();
            BASEURL = "https://data.portfolio.hu/all/json/";
        }

        public StockRequest(StockType ticker, HttpClient httpClient)
        {
            this.ticker = ticker;
            this.httpClient = httpClient;
        }

        public async Task<T> LastDay()
        {
            string json = await httpClient
                .GetStringAsync($"{BASEURL}{ticker.Name}:interval=1D")
                .ConfigureAwait(false);

            return PARSER.Parse(this, json);
        }

        /*await stockMarket.Get(ticker).LastDay();
        await stockMarket.Get(ticker).LastMonth();
        await stockMarket.Get(ticker).LastThreeMonths();
        await stockMarket.Get(ticker).LastSixMonths();
        await stockMarket.Get(ticker).LastYear();
        await stockMarket.Get(ticker).LastFiveYears();*/
    }
}
