using System;

namespace PoLaKoSz.Portfolio.Exceptions
{
    public class ArchivedArticleException : Exception
    {
        public ArchivedArticleException(string message)
            : base(message) { }

        public ArchivedArticleException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
