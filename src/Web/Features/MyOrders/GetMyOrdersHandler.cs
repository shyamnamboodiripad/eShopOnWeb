using MediatR;
using Microsoft.eShopWeb.ApplicationCore.Entities.Tax;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.ApplicationCore.Specifications;
using Microsoft.eShopWeb.Web.ViewModels;

namespace Microsoft.eShopWeb.Web.Features.MyOrders;

public class GetMyOrdersHandler : IRequestHandler<GetMyOrders, IEnumerable<OrderViewModel>>
{
    private readonly IReadRepository<Order> _orderRepository;

    public GetMyOrdersHandler(IReadRepository<Order> orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<IEnumerable<OrderViewModel>> Handle(GetMyOrders request,
        CancellationToken cancellationToken)
    {
        var specification = new CustomerOrdersSpecification(request.UserName);
        var orders = await _orderRepository.ListAsync(specification, cancellationToken);

        var orderViewModels = new List<OrderViewModel>();
        foreach (var order in orders)
        {
            var total = order.Total();
            var tax = GetSalesTax(total, order.ShipToAddress.City, order.ShipToAddress.State, cancellationToken);
            var totalWithTax = total + tax;
            orderViewModels.Add(new OrderViewModel
            {
                OrderDate = order.OrderDate,
                OrderNumber = order.Id,
                ShippingAddress = order.ShipToAddress,
                Total = total,
                Tax = tax,
                TotalWithTax = totalWithTax
            });
        }

        return orderViewModels;
    }

    public decimal GetSalesTax(decimal total, string city, string state, CancellationToken cancellationToken)
    {
        var taxCalculator = new SalesTaxCalculator();
        return taxCalculator.GetSalesTax(total, city, state);
    }
}
