using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PoLaKoSz.Portfolio.Tests.Integration.DataAccessLayer
{
    internal class FakeWebClient : HttpClient
    {
        private readonly OfflineMessageHandler _messageHandler;

        public FakeWebClient()
            : this(new OfflineMessageHandler())
        {
        }

        public FakeWebClient(OfflineMessageHandler messageHandler)
            : base(messageHandler)
        {
            _messageHandler = messageHandler;
        }

        internal void SetServerResponse(string sourceCode)
        {
            _messageHandler.SetStringContentTo(sourceCode);
        }

        internal class OfflineMessageHandler : HttpMessageHandler
        {
            private string _content;

            internal void SetStringContentTo(string content)
            {
                _content = content;
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                return Task.FromResult(new HttpResponseMessage() { Content = new StringContent(_content) });
            }
        }
    }
}
