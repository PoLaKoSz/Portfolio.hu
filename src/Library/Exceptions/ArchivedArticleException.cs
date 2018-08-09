using System;

namespace PoLaKoSz.hu.Portfolio_hu_API.Exceptions
{
    public class ArchivedArticleException : Exception
    {
        public ArchivedArticleException(string message)
            : base(message) { }

        public ArchivedArticleException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
