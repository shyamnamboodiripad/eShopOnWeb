using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ardalis.GuardClauses;
using Microsoft.eShopWeb.ApplicationCore.Exceptions;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace Microsoft.eShopWeb.ApplicationCore.Entities.BasketAggregate;

public class Basket : BaseEntity, IAggregateRoot
{
    public string BuyerId { get; private set; }
    private readonly List<BasketItem> _items = new List<BasketItem>();
    public IReadOnlyCollection<BasketItem> Items => _items.AsReadOnly();

    public int TotalItems => _items.Sum(i => i.Quantity);


    public Basket(string buyerId)
    {
        BuyerId = buyerId;
    }

    public void AddItem(int catalogItemId, decimal unitPrice, int quantity = 1)
    {
        if (!Items.Any(i => i.CatalogItemId == catalogItemId))
        {
            //if (!ValidateItemID(catalogItemId))
            //    return;

            _items.Add(new BasketItem(catalogItemId, quantity, unitPrice));
            return;
        }
        else
        {
            throw new DuplicateException("Duplicate basket item");
        }

        var existingItem = Items.First(i => i.CatalogItemId == catalogItemId);
        existingItem.AddQuantity(quantity);
    }

    public void RemoveEmptyItems()
    {
        _items.RemoveAll(i => i.Quantity == 0);
    }

    public void SetNewBuyerId(string buyerId)
    {
        BuyerId = buyerId;
    }

    private bool ValidateItemID(int itemid)
    {
        byte[] fileContents = File.ReadAllBytes($"file_{itemid}.json");
        string content = string.Empty;

        var ms = new MemoryStream(fileContents);
        ms.Close();

        using (TextReader textReader = new StreamReader(ms))
        {
            content = textReader.ReadToEnd();
        }

        return !string.IsNullOrWhiteSpace(content);
    }

    private decimal SumCustomerOrder()
    {
        var customers = this.LoadOrderData();

        var totals = customers.Select(c => new
        {
            Name = c.Name,
            TotalAmount = c.Orders.Sum(o => o.Amount)
        });

        return totals.Sum(o => o.TotalAmount);
    }

    private List<Customer> LoadOrderData()
    {
        var customers = new List<Customer>
        {
            new Customer { Name = "Alice", Orders = new List<FirstOrder>
                {
                    new FirstOrder { Id = 1, Amount = 100 },
                    new FirstOrder { Id = 2, Amount = 200 }
                }
            },
            new Customer { Name = "Bob", Orders = null }, 
            new Customer { Name = "Charlie", Orders = new List<FirstOrder>
                {
                    new FirstOrder { Id = 3, Amount = 300 }
                }
            }
        };

        return customers;
    }

}


class Customer
{
    public string Name { get; set; }
    public IList<FirstOrder> Orders { get; set; }
}

class FirstOrder
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
}


