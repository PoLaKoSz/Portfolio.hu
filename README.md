# Portfolio.hu

A .NET standard 2.0 library to save data from [Portfolio.hu](https://portfolio.hu/).

[![Portfolio.hu API MyGet Build Status](https://www.myget.org/BuildSource/Badge/polakosz?identifier=853f2014-fff0-48c3-b6c5-8cee92e4b824)](https://www.myget.org/feed/polakosz/package/nuget/Portfolio.hu.API)

## Example

``` c#
var portfolio = new Portfolio();
var stockMarket = portfolio.StockMarket;
var ticker = new ForeignCurrency("EURHUF=X");

await stockMarket.Get(ticker).LastDay();
await stockMarket.Get(ticker).LastMonth();
await stockMarket.Get(ticker).LastThreeMonths();
await stockMarket.Get(ticker).LastSixMonths();
await stockMarket.Get(ticker).LastYear();
await stockMarket.Get(ticker).LastFiveYears();
```
