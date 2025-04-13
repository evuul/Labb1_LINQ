using Labb1_LINQ.Data;
using Labb1_LINQ.models;

namespace Labb1_LINQ;

class Program
{
    static void Main(string[] args)
    {
        using var context = new LinqLabbContext();
        var dataHelper = new DataHelper(context);
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Välj ett alternativ:");
            Console.WriteLine("1. Visa elektronikprodukter");
            Console.WriteLine("2. Leverantörer med låg lagerstatus");
            Console.WriteLine("3. Ordervärde förra månaden");
            Console.WriteLine("4. Topp 3 produkter");
            Console.WriteLine("5. Visa alla produkter");
            Console.WriteLine("6. Visa ordrar över 1000 kr");
            Console.WriteLine("0. Avsluta");
            Console.Write("\nDitt val: ");

            string input = Console.ReadLine();
            Console.Clear();

            try
            {
                switch (input)
                {
                    case "1":
                        dataHelper.GetElectronics();
                        break;
                    case "2":
                        dataHelper.SuppliersWithLowStock();
                        break;
                    case "3":
                        dataHelper.OrderValueLastMonth();
                        break;
                    case "4":
                        dataHelper.ShowTop3Products();
                        break;
                    case "5":
                        dataHelper.ShowAllProducts();
                        break;
                    case "6":
                        dataHelper.ShowOrdersOver1000();
                        break;
                    case "0":
                        running = false;
                        Console.WriteLine("Avslutar programmet.");
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val. Försök igen.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ett fel inträffade: {ex.Message}");
            }

            if (running)
            {
                Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
                Console.ReadKey();
            }
        }
    }
}