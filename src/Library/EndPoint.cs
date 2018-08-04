using HtmlAgilityPack;
using PoLaKoSz.hu.Portfolio_hu_API.DataAccessLayer;
using PoLaKoSz.hu.Portfolio_hu_API.Middlewares;
using System;
using System.Collections.Generic;

namespace PoLaKoSz.hu.Portfolio_hu_API
{
    public abstract class EndPoint
    {
        public Uri EndpointAddress { get; set; }
        public IWebClient WebClient { get; set; }
        public List<BaseMiddleware> Middlewares { get; set; }


        
        public EndPoint(string relativeAddress)
            : this(new Uri(new Uri(Constans.BaseAddress), relativeAddress)) { }
        public EndPoint(Uri endpointAddress)
            : this(endpointAddress, new WebClient()) { }
        public EndPoint(Uri endpointAddress, IWebClient webClient)
        {
            EndpointAddress = endpointAddress;
            WebClient = webClient;
            Middlewares = new List<BaseMiddleware>();
        }



        /// <summary>
        /// Run middlewares and download the EndpointAddress's contet
        /// </summary>
        /// <returns>Raw source code modified by middlewares</returns>
        protected string LoadWebpage()
        {
            foreach (var middleware in Middlewares)
                middleware.PreEvent(this);

            string sourceCode = WebClient.DownloadString(EndpointAddress);

            var rootNode = GetRootNode(sourceCode);

            for (int i = Middlewares.Count - 1; 0 <= i; i--)
                Middlewares[i].PostEvent(rootNode);

            return sourceCode;
        }

        private HtmlNode GetRootNode(string sourceCode)
        {
            HtmlDocument document = new HtmlDocument();

            document.LoadHtml(sourceCode);

            return document.DocumentNode;
        }
    }
}
