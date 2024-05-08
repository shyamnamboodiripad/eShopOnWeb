namespace Microsoft.eShopWeb.ApplicationCore.Entities.Tax;

public class StateAndLocalTaxHelper
{
    public static decimal GetStateTaxRate(string state)
    {
        return state switch
        {
            "WA" => 6.5m,
            "CA" => 7.25m,
            _ => 0m
        };
    }

    public static decimal GetLocalTaxRate(string city)
    {
        return city switch
        {
            "Redmond" => 3m,
            "Seattle" => 3.5m,
            "Los Angeles" => 3.2m,
            "San Francisco" => 3.2m,
            _ => 0m
        };
    }
}

