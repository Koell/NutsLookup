# NutsLookup (C#)

Fast NUTS3 code lookup by country (alpha-2) and ZIP code using an embedded SQLite database loaded into memory.

## Usage
```csharp
using var service = new NutsLookup.NutsService();
var nutsCode = service.GetNutsCode("DE", "10115");
Console.WriteLine(nutsCode);  // Example: 'DE300'
```

## Installation
Coming soon via NuGet:
```
dotnet add package NutsLookup
```

## License

MIT

---

## Eurostat Copyright Notice

Please note that nuts-lookup is not developed, maintained, or affiliated with Eurostat. The following copyright notice from Eurostat regards their data, which underpins nuts-lookup:

> In addition to the general copyright and licence policy applicable to the whole Eurostat website, the following specific provisions apply to the datasets you are downloading. The download and usage of these data is subject to the acceptance of the following clauses:
>
> The Commission agrees to grant the non-exclusive and not transferable right to use and process the Eurostat/GISCO geographical data downloaded from this page (the "data").
>
> The permission to use the data is granted on condition that:
>
> - the data will not be used for commercial purposes;
> - the source will be acknowledged. A copyright notice, as specified below, will have to be visible on any printed or electronic publication using the data downloaded from this page.

### Copyright Notice

When data downloaded from this page is used in any printed or electronic publication, in addition to any other provisions applicable to the whole Eurostat website, the data source will have to be acknowledged in the legend of the map and in the introductory page of the publication with the following copyright notice:

- EN: © EuroGeographics for the administrative boundaries
- FR: © EuroGeographics pour les limites administratives
- DE: © EuroGeographics bezüglich der Verwaltungsgrenzen

For publications in languages other than English, French, or German, the translation of the copyright notice in the language of the publication shall be used.

If you intend to use the data commercially, please contact EuroGeographics for information regarding their licence agreements.
