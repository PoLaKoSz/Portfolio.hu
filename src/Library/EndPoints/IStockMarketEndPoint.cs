using PoLaKoSz.Portfolio.Models;

namespace PoLaKoSz.Portfolio.EndPoints
{
    public interface IStockMarketEndPoint
    {
        Share Get(ShareType stock);

        ForeignCurrency Get(ForeignCurrencyType stock);
    }
}
