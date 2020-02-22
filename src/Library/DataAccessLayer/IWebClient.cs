using System;
using System.Text;

namespace PoLaKoSz.Portfolio.DataAccessLayer
{
    public interface IWebClient
    {
        Encoding Encoding { get; set; }

        /// <inheritdoc />
        string DownloadString(Uri address);
    }
}
