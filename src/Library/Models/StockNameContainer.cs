using System;

namespace PoLaKoSz.hu.Portfolio_hu_API.Models
{
    public class StockNameContainer
    {
        public StockNameContainer(string name, string fullName, string shortName, string chartName)
        {
            Name = name;
            FullName = fullName;
            ShortName = shortName;
            ChartName = chartName;
        }

        public string Name { get; }

        public string FullName { get; }

        public string ShortName { get; }

        public string ChartName { get; }
    }
}
