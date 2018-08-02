using System;

namespace Library.DataAccessLayer
{
    public interface IWebClient
    {
        string DownloadString(Uri address);
    }
}
