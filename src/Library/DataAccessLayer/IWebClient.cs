using System;

namespace PoLaKoSz.hu.Portfolio_hu_API.DataAccessLayer
{
    public interface IWebClient
    {
        string DownloadString(Uri address);
    }
}
