namespace Microsoft.eShopWeb.ApplicationCore.Entities.Tax;

public class StateAndLocalTaxHelper
{
    public static decimal GetTaxRate(string city, string state)
    {
        var cityTaxRate =
            city switch
            {
                "Redmond" => 3m,
                "Seattle" => 3.5m,
                "Los Angeles" => 3.2m,
                "San Francisco" => 3.5m,
                _ => 0m
            };

        var stateTaxRate =
            state switch
            {
                "WA" => 6.5m,
                "CA" => 7.25m,
                _ => 0m
            };

        return cityTaxRate + stateTaxRate;
    }
}

