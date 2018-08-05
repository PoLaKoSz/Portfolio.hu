using System;
using PoLaKoSz.hu.Portfolio_hu_API.DataAccessLayer;

namespace UnitTests.DataAccessLayer
{
    internal class FakeWebClient : IWebClient
    {
        private string _sourceCode { get; }



        public FakeWebClient(string sourceCode)
        {
            _sourceCode = sourceCode;
        }



        public string DownloadString(Uri address)
        {
            return _sourceCode;
        }
    }
}
