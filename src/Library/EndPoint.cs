using System;
using System.Net.Http;

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
        public HttpClient HttpClient { get; set; }

        public EndPoint(string relativeAddress)
            : this(new Uri(new Uri(Constans.BaseAddress), relativeAddress)) { }
        public EndPoint(Uri endpointAddress)
            : this(endpointAddress, new HttpClient()) { }
        public EndPoint(Uri endpointAddress, HttpClient httpClient)
        {
            EndpointAddress = endpointAddress;

            HttpClient = httpClient;
        }

        protected string GetAsync(string additionalPath)
        {
            var uriBuilder = new UriBuilder(EndpointAddress);
            uriBuilder.Path += additionalPath;

            string response = HttpClient.GetStringAsync(uriBuilder.Uri).ConfigureAwait(false)
                .GetAwaiter().GetResult();

            System.IO.File.WriteAllText($"{DateTime.Now.ToString("HH_mm_ss")}.html", response);

            return response;
        }
    }
}
