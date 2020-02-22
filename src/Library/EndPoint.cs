using HtmlAgilityPack;
using PoLaKoSz.Portfolio.DataAccessLayer;
using System;
using System.Net;
using System.Text;

namespace PoLaKoSz.Portfolio
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

        public EndPoint(string relativeAddress)
            : this(new Uri(new Uri(Constans.BaseAddress), relativeAddress)) { }
        public EndPoint(Uri endpointAddress)
            : this(endpointAddress, new DataAccessLayer.WebClient()) { }
        public EndPoint(Uri endpointAddress, IWebClient webClient)
        {
            EndpointAddress = endpointAddress;

            WebClient = webClient;
            WebClient.Encoding = Encoding.GetEncoding("ISO-8859-1");
        }

        protected string GetAsync(string additionalPath)
        {
            var uriBuilder = new UriBuilder(EndpointAddress);
            uriBuilder.Path += additionalPath;

            string response = WebClient.DownloadString(uriBuilder.Uri);

            System.IO.File.WriteAllText($"{DateTime.Now.ToString("HH_mm_ss")}.html", response);

            return response;
        }

        /// <summary>
        /// Run middlewares and download the EndpointAddress's contet
        /// </summary>
        /// <returns>Raw source code modified by middlewares</returns>
        /// <exception cref="WebException"></exception>
        protected string LoadWebpage()
        {
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

            return sourceCode;
        }
    }
}
