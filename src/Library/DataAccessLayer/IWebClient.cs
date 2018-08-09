using System;
using System.Text;

namespace PoLaKoSz.hu.Portfolio_hu_API.DataAccessLayer
{
    public interface IWebClient
    {
        Encoding Encoding { get; set; }

        /// <inheritdoc />
        string DownloadString(Uri address);
    }
}
