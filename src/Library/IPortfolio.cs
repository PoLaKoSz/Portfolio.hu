using PoLaKoSz.Portfolio.EndPoints;

namespace PoLaKoSz.Portfolio
{
    public interface IPortfolio
    {
        IStockMarketEndPoint StockMarket { get; }
    }
}
