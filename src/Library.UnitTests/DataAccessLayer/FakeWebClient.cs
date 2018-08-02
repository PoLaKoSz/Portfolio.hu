using System;
using Library.DataAccessLayer;

namespace Library_UnitTests.DataAccessLayer
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
