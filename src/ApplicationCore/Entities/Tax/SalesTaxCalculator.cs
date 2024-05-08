using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.ApplicationCore.Entities.Tax;

public class SalesTaxCalculator
{
    public virtual decimal GetSalesTax(decimal total, string city, string state)
    {
        var taxRate = StateAndLocalTaxHelper.GetTaxRate(city, state);
        return total * taxRate / 100;
    }

    public virtual decimal AddSalesTax(decimal total, string city, string state)
    {
        var taxRate = StateAndLocalTaxHelper.GetTaxRate(city, state);
        return total + (total * taxRate / 100);
    }
}
