using PoLaKoSz.Portfolio.DataAccessLayer;
using System;
using System.Text;

namespace PoLaKoSz.Portfolio.Tests.Integration.DataAccessLayer
{
    class FakeWebClient : IWebClient
    {
        private string _serverResponse;

        public FakeWebClient()
        {
            _serverResponse = "";
        }

        public Encoding Encoding { get; set; }

        public void SetServerResponse(string response)
        {
            _serverResponse = response;
        }

        public string DownloadString(Uri address)
        {
            return _serverResponse;
        }
    }
}
