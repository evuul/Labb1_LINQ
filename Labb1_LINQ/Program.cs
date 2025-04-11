using Labb1_LINQ.Data;
using Labb1_LINQ.models;

namespace Labb1_LINQ;

class Program
{
    static void Main(string[] args)
    {
        using var context = new LinqLabbContext();
        var dataHelper = new DataHelper(context);
        
        dataHelper.GetElectronics();
        Console.WriteLine("--------------------------------");
        dataHelper.SuppliersWithLowStock();
        Console.WriteLine("--------------------------------");
        dataHelper.OrderValueLastMonth();
        Console.WriteLine("--------------------------------");
        dataHelper.ShowTop3Products();
        Console.WriteLine("--------------------------------");
        dataHelper.ShowAllProducts();
        Console.WriteLine("--------------------------------");
        dataHelper.ShowOrdersOver1000();

    }
}