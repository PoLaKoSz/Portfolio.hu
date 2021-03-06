﻿using System;
using PoLaKoSz.hu.Portfolio_hu_API.DataAccessLayer;
using PoLaKoSz.hu.Portfolio_hu_API.Deserializers;
using PoLaKoSz.hu.Portfolio_hu_API.Models;

namespace PoLaKoSz.hu.Portfolio_hu_API.EndPoints
{
    public class StockMarketEndPoint : EndPoint
    {
        private static readonly StockApiDeserializer _parser;

        static StockMarketEndPoint()
        {
            _parser = new StockApiDeserializer();
        }

        public StockMarketEndPoint(IWebClient webClient)
            : base(new Uri("https://data.portfolio.hu/all/json/"), webClient) { }

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
