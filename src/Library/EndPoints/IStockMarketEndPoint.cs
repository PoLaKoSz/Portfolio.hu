using System;
using System.Threading.Tasks;
using PoLaKoSz.Portfolio.Models;

namespace PoLaKoSz.Portfolio.EndPoints
{
    public interface IStockMarketEndPoint
    {
        Task<Share> GetShare(Func<StockMarketRequest<ShareType>, StockMarketRequest<ShareType>> request);

        Task<ForeignCurrency> GetForeignCurrency(Func<StockMarketRequest<ForeignCurrencyType>, StockMarketRequest<ForeignCurrencyType>> request);
    }
}
