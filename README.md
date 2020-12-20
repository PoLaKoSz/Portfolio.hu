# Portfolio.hu API

A .NET standard 2.0 library to save data from [Portfolio.hu](https://portfolio.hu/).

## Install

via [NuGet](https://www.nuget.org/packages/Portfolio.hu.API)

``` sh
dotnet add package Portfolio.hu.API
```

### Quick start

``` c#
using PoLaKoSz.hu.Portfolio_hu_API.DataAccessLayer;
using PoLaKoSz.hu.Portfolio_hu_API.EndPoints;
using PoLaKoSz.hu.Portfolio_hu_API.Models;

// ...

var client = new WebClient();
var stockMarket = new StockMarketEndPoint(client);
Share ticker = stockMarket.Get(new ShareType("OTP"));
```
