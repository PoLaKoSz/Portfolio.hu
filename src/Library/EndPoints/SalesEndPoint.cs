using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using PoLaKoSz.hu.Portfolio_hu_API.DataAccessLayer;
using PoLaKoSz.hu.Portfolio_hu_API.Deserializers;
using PoLaKoSz.hu.Portfolio_hu_API.Models;

namespace PoLaKoSz.hu.Portfolio_hu_API.EndPoints
{
    public class SalesEndPoint
    {
        private readonly IWebClient webClient;
        private readonly SalesEndPointDeserializer deserializer;

        public SalesEndPoint(IWebClient webClient)
        {
            this.webClient = webClient;
            deserializer = new SalesEndPointDeserializer();
        }

        /// <exception cref="NodeNotFoundException" />
        public IReadOnlyList<Sale> For(ShareType stock)
        {
            Uri uri = new Uri($"https://portfolio.hu/arfolyam/koteslista/{stock.Name}");
            string html = webClient.DownloadString(uri);
            return deserializer.ParseTable(html);
        }

        /// <exception cref="ArgumentException" />
        /// <exception cref="NodeNotFoundException" />
        public IReadOnlyList<ShareType> GetAvailableOptions()
        {
            Uri uri = new Uri("https://portfolio.hu/arfolyam/koteslista/BTC");
            string html = webClient.DownloadString(uri);
            return deserializer.ParseTickerSelector(html);
        }
    }
}
