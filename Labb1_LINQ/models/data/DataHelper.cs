using Labb1_LINQ.models;
using Labb1_LINQ.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb1_LINQ.Data;

public class DataHelper
{
    private readonly LinqLabbContext _context;

    public DataHelper(LinqLabbContext context)
    {
        _context = context;
    }
    // Uppgift 1
    public void GetElectronics()
    {
        var electronics = _context.Products
            .Include(p => p.Category) // viktigt!
            .Where(p => p.Category.Name == "Electronics")
            .OrderByDescending(p => p.Price)
            .ToList();

        foreach (var product in electronics)
        {
            Console.WriteLine($"Produkt: {product.Name}, Pris: {product.Price}");
        }
    }

    // Uppgift 2
    public void SuppliersWithLowStock()
    {
        var SuppliersWithLowStock = _context.Products
            .Where(p => p.StockQuantity < 10)
            .GroupBy(p => p.Supplier)
            .Select(g => new
            {
                Supplier = g.Key,
                LowStockProducts = g.ToList()
            })
            .ToList();

        foreach (var supplierGroup in SuppliersWithLowStock)
        {
            if (supplierGroup.Supplier != null) // Hantera potentiella null-leverantörer
            {
                Console.WriteLine($"{supplierGroup.Supplier.SupplierId}- Leverantör: {supplierGroup.Supplier.Name}");

                foreach (var product in supplierGroup.LowStockProducts)
                {
                    Console.WriteLine($"  - Produkt: {product.Name}, Lager: {product.StockQuantity}");
                }
            }
        }
    }
    
    // Uppgift 3
    public void OrderValueLastMonth()
    {
        var lastMonth = DateTime.Now.AddMonths(-1);
        var totalOrderValue = _context.OrderDetails
            .Include(od => od.Product)
            .Where(od => od.Order.OrderDate >= lastMonth)
            .Sum(od => od.Quantity * od.Product.Price);

        Console.WriteLine($"Totalt ordervärde för den senaste månaden: {totalOrderValue:C}");
    }
    
    // Uppgift 4

    public void ShowTop3Products()
    {
        var top3Products = _context.OrderDetails
            .Include(od => od.Product)
            .GroupBy(od => od.Product)
            .Select(g => new
            {
                Product = g.Key.Name,
                TotalQuantity = g.Sum(od => od.Quantity)
            })
            .OrderByDescending(x => x.TotalQuantity)
            .Take(3)
            .ToList();

        foreach (var product in top3Products)
        {
            Console.WriteLine($"Produkt: {product.Product}, Total: {product.TotalQuantity}st");
        }
    }
    
    // Uppgift 5
    
    public void ShowAllProducts()
    {
        var categoryProductCounts = _context.Categories
            .Select(category => new
            {
                CategoryName = category.Name,
                ProductCount = category.Products.Count
            })
            .ToList();

        foreach (var item in categoryProductCounts)
        {
            Console.WriteLine($"Kategori: {item.CategoryName}, Antal produkter: {item.ProductCount}st");
        }
    }
    
    // Uppgift 6
    // Hämta alla ordrar med tillhörande kunduppgifter och orderdetaljer där totalbeloppet överstiger 1000 kr
    
    public void ShowOrdersOver1000()
    {
        var ordersOver1000 = _context.Orders
            .Include(o => o.Customer)
            .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
            .Where(o => o.OrderDetails.Sum(od => od.Quantity * od.Product.Price) > 1000)
            .ToList();

        foreach (var order in ordersOver1000)
        {
            Console.WriteLine($"Order ID: {order.OrderId}, Kund: {order.Customer.Name}, Totalbelopp: {order.OrderDetails.Sum(od => od.Quantity * od.Product.Price):C}");
        }
    }
}