using System;
using System.Net.Http;

namespace PoLaKoSz.Portfolio
{
    public abstract class EndPoint
    {
        public EndPoint(string relativeAddress)
            : this(new Uri(new Uri(Constans.BaseAddress), relativeAddress))
        {
        }

        public EndPoint(Uri endpointAddress)
            : this(endpointAddress, new HttpClient())
        {
        }

        public EndPoint(Uri endpointAddress, HttpClient httpClient)
        {
            EndpointAddress = endpointAddress;

            HttpClient = httpClient;
        }

        /// <summary>
        /// Gets or sets the URL that will be called in the web request.
        /// </summary>
        public Uri EndpointAddress { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="HttpClient"/> which will call the
        /// endpoint address.
        /// </summary>
        public HttpClient HttpClient { get; set; }

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
