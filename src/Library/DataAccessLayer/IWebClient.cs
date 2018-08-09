using System;

namespace PoLaKoSz.hu.Portfolio_hu_API.DataAccessLayer
{
    public interface IWebClient
    {
        /// <inheritdoc />
        string DownloadString(Uri address);
    }
}
