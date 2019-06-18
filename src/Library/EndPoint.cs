using HtmlAgilityPack;
using PoLaKoSz.hu.Portfolio_hu_API.DataAccessLayer;
using PoLaKoSz.hu.Portfolio_hu_API.Middlewares;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace PoLaKoSz.hu.Portfolio_hu_API
{
    public abstract class EndPoint
    {
        /// <summary>
        /// This URL will be called in the web request
        /// </summary>
        public Uri EndpointAddress { get; set; }

        /// <summary>
        /// Call the endpoint throw this class
        /// </summary>
        public IWebClient WebClient { get; set; }

        /// <summary>
        /// These classes will be executed before and after the web request
        /// </summary>
        public List<BaseMiddleware> Middlewares { get; set; }


        
        public EndPoint(string relativeAddress)
            : this(new Uri(new Uri(Constans.BaseAddress), relativeAddress)) { }
        public EndPoint(Uri endpointAddress)
            : this(endpointAddress, new DataAccessLayer.WebClient()) { }
        public EndPoint(Uri endpointAddress, IWebClient webClient)
        {
            EndpointAddress = endpointAddress;

            WebClient = webClient;
            WebClient.Encoding = Encoding.GetEncoding("ISO-8859-1");

            Middlewares = new List<BaseMiddleware>();
        }



        /// <summary>
        /// Run middlewares and download the EndpointAddress's contet
        /// </summary>
        /// <returns>Raw source code modified by middlewares</returns>
        /// <exception cref="System.Net.WebException"></exception>
        protected string LoadWebpage()
        {
            foreach (var middleware in Middlewares)
                middleware.PreEvent(this);

            string sourceCode = "";

            try
            {
                sourceCode = WebClient.DownloadString(EndpointAddress);
            }
            catch (WebException ex)
            {
                string message = $"HTTP status: {ex.Status}. Can not load URL: {EndpointAddress.ToString()}";
                throw new WebException(message, ex);
            }

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
