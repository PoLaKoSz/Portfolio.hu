using PoLaKoSz.hu.Portfolio_hu_API.DataAccessLayer;
using System;
using System.Text;

namespace Integration.DataAccessLayer
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
