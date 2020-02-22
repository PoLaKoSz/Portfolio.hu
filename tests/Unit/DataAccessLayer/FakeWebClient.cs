using System;
using System.Text;
using PoLaKoSz.Portfolio.DataAccessLayer;

namespace PoLaKoSz.Portfolio.Tests.Unit.DataAccessLayer
{
    internal class FakeWebClient : IWebClient
    {
        private readonly string _sourceCode;


        public Encoding Encoding { get; set; }



        public FakeWebClient(string sourceCode)
        {
            _sourceCode = sourceCode;
            Encoding = Encoding.UTF8;
        }



        public string DownloadString(Uri address)
        {
            return _sourceCode;
        }
    }
}
