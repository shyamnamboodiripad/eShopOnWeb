using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.ApplicationCore.Entities.Tax;

public class StateAndLocalTaxService
{
    public static async Task<decimal> GetStateTaxRateAsync(string state, CancellationToken cancellationToken)
    {
        // Simulate delay to fetch data from a remote service.
        await Task.Delay(10);

        return state switch
        {
            "WA" => 6.5m,
            "CA" => 7.25m,
            _ => 0m
        };
    }

    public static async Task<decimal> GetLocalTaxRateAsync(string city, CancellationToken cancellationToken)
    {
        // Simulate delay to fetch data from a remote service.
        await Task.Delay(10);

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

