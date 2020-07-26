using System.Threading.Tasks;
using PoLaKoSz.Portfolio.Models;

namespace PoLaKoSz.Portfolio.EndPoints
{
    public interface IStockMarketEndPoint
    {
        Task<Share> Get(ShareType stock);

        Task<ForeignCurrency> Get(ForeignCurrencyType stock);
    }
}
