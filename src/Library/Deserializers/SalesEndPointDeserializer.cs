using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using PoLaKoSz.hu.Portfolio_hu_API.Models;

namespace PoLaKoSz.hu.Portfolio_hu_API.Deserializers
{
    public class SalesEndPointDeserializer
    {
        /// <exception cref="NodeNotFoundException" />
        public IReadOnlyList<Sale> ParseTable(string html)
        {
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            HtmlNode rootNode = htmlDocument.GetElementbyId("sales-table");
            if (rootNode == null)
            {
                throw new NodeNotFoundException("Couldn't find table containing the sales list.");
            }

            HtmlNodeCollection rows = rootNode.SelectNodes("./tbody/tr");
            List<Sale> results = new List<Sale>();
            if (rows == null)
            {
                return results;
            }

            foreach (HtmlNode row in rows)
            {
                int changeDirection = row.HasClass("up") ? 1 : 0;
                if (row.HasClass("down"))
                    changeDirection = -1;

                results.Add(new Sale
                {
                    Time = DateTime.Parse(row.SelectNodes("./td")[0].InnerText),
                    Price = double.Parse(row.SelectNodes("./td")[2].InnerText),
                    Change = float.Parse(row.SelectNodes("./td")[3].InnerText.Replace("%", "")),
                    ChangeDirection = changeDirection,
                    Count = int.Parse(row.SelectNodes("./td")[4].InnerText),
                    Value = long.Parse(row.SelectNodes("./td")[5].InnerText),
                });
            }
            return results;
        }

        /// <exception cref="ArgumentException" />
        /// <exception cref="NodeNotFoundException" />
        public IReadOnlyList<ShareType> ParseTickerSelector(string html)
        {
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            HtmlNode rootNode = htmlDocument.GetElementbyId("ticker-selector");
            if (rootNode == null)
            {
                throw new NodeNotFoundException("Couldn't find select tag containing the ticker list.");
            }

            HtmlNodeCollection options = rootNode.SelectNodes("./option");
            List<ShareType> tickers = new List<ShareType>();
            if (options == null)
            {
                return tickers;
            }

            foreach (HtmlNode option in options)
            {
                string tickerName = option.GetAttributeValue("value", null);
                if (string.IsNullOrEmpty(tickerName))
                {
                    throw new ArgumentException("Option HTML tag doesn't have value attribute!");
                }

                tickers.Add(new ShareType(tickerName));
            }

            return tickers;
        }
    }
}
