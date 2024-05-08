using System.Threading;
using System.Threading.Tasks;

﻿namespace Microsoft.eShopWeb.ApplicationCore.Entities.Tax;

public class AdvancedSalesTaxCalculator : SalesTaxCalculator
{
    public override decimal GetSalesTax(decimal total, string city, string state)
    {
        // TODO: Some advanced tax processing.
        return base.GetSalesTax(total, city, state);
    }

    public override decimal AddSalesTax(decimal total, string city, string state)
    {
        // TODO: Some advanced tax processing.
        return base.AddSalesTax(total, city, state);
    }
}
