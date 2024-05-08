using System.Threading;
using System.Threading.Tasks;   
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
        var totalWithTax = calculator.GetSalesTax(total, "Redmond", "WA");
        Assert.Equal(9.5m, totalWithTax);
    }

    [Fact]
    public void CanGetSalesTaxForLA()
    {
        var calculator = new SalesTaxCalculator();
        var total = 100;
        var totalWithTax = calculator.GetSalesTax(total, "Los Angeles", "CA");
        Assert.Equal(10.45m, totalWithTax);
    }

    [Fact]
    public void CanAddSalesTaxForRedmond()
    {
        var calculator = new SalesTaxCalculator();
        var total = 100;
        var totalWithTax = calculator.AddSalesTax(total, "Redmond", "WA");
        Assert.Equal(109.5m, totalWithTax);
    }

    [Fact]
    public void CanAddSalesTaxForLA()
    {
        var calculator = new SalesTaxCalculator();
        var total = 100;
        var totalWithTax = calculator.AddSalesTax(total, "Los Angeles", "CA");
        Assert.Equal(110.45m, totalWithTax);
    }
}
