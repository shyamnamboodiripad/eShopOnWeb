using Microsoft.eShopWeb.ApplicationCore.Entities.Tax;
using Xunit;

namespace Microsoft.eShopWeb.UnitTests.ApplicationCore.Entities.Tax;

public class SalesTaxCalculatorTests
{
    [Fact]
    public void CanGetSalesTaxForRedmond()
    {
        var calculator = new SalesTaxCalculator();
        var total = 100;
        var tax = calculator.GetSalesTax(total, "Redmond", "WA");
        Assert.Equal(9.5m, tax);
    }

    [Fact]
    public void CanGetSalesTaxForLosAngeles()
    {
        var calculator = new SalesTaxCalculator();
        var total = 100;
        var tax = calculator.GetSalesTax(total, "Los Angeles", "CA");
        Assert.Equal(10.45m, tax);
    }

    [Fact]
    public void CanGetSalesTaxForSeattle()
    {
        var calculator = new SalesTaxCalculator();
        var total = 100;
        var tax = calculator.GetSalesTax(total, "Seattle", "WA");
        Assert.Equal(10, tax);
    }

    [Fact]
    public void CanGetSalesTaxForSanFrancisco()
    {
        var calculator = new SalesTaxCalculator();
        var total = 100;
        var tax = calculator.GetSalesTax(total, "San Francisco", "CA");
        Assert.Equal(10.75m, tax);
    }
}
