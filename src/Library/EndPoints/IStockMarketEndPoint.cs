using PoLaKoSz.Portfolio.Models;

namespace PoLaKoSz.Portfolio.EndPoints
{
    public interface IStockMarketEndPoint
    {
        StockRequest<ForeignCurrency> Get(ForeignCurrencyType ticker);

        StockRequest<Share> Get(ShareType ticker);
    }
}
