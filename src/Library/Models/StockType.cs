using System;

namespace PoLaKoSz.hu.Portfolio_hu_API.Models
{
    /// <summary>
    /// Class to quickly identify a stock.
    /// </summary>
    public class StockType
    {
        /// <summary>
        /// Initialize a new instance.
        /// </summary>
        /// <param name="ticker">In the API response this is the value
        /// of the 'ticker' token.</param>
        public StockType(string ticker)
        {
            Name = ticker;
        }

        /// <summary>
        /// Gets the fully qualified name of the stock.
        /// </summary>
        public string Name { get; }
    }
}
