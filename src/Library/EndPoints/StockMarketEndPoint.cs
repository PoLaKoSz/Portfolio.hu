using System;
using System.Net.Http;
using PoLaKoSz.Portfolio.Deserializers;
using PoLaKoSz.Portfolio.Models;

namespace PoLaKoSz.Portfolio.EndPoints
{
    public class StockMarketEndPoint : EndPoint
    {
        private static readonly StockApiDeserializer _parser;

        static StockMarketEndPoint()
        {
            _parser = new StockApiDeserializer();
        }

        public StockMarketEndPoint()
            : this(new HttpClient())
        {
        }

        public StockMarketEndPoint(HttpClient httpClient)
            : base(new Uri("https://data.portfolio.hu/all/json/"), httpClient)
        {
        }

        public Share Get(ShareType stock)
        {
            string json = base.GetAsync($"{stock.Name}:interval=1D&resolution=600");

            return _parser.AsShare(json);
        }

        public ForeignCurrency Get(ForeignCurrencyType stock)
        {
            string json = base.GetAsync($"{stock.Name}:interval=1D&resolution=600");

            return _parser.AsForex(json);
        }
    }
}
