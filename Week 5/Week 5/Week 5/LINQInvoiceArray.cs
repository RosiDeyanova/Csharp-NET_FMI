using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_5
{
    public class LINQInvoiceArray
    {
        static Invoice[] invoices =
           {
               new Invoice( 83, "Electric sander", 7, 57.98M ),
               new Invoice( 24, "Power saw", 18, 99.99M ),
               new Invoice( 7, "Sledge hammer", 11, 21.5M ),
               new Invoice( 77, "Hammer", 76, 11.99M ),
               new Invoice( 39, "Lawn mower", 3, 79.5M ),
               new Invoice( 68, "Screwdriver", 106, 6.99M ),
               new Invoice( 56, "Jig saw", 21, 11M ),
               new Invoice( 3, "Wrench", 34, 7.5M )
           };

        public static void SortByDescription(Invoice[] invoices)
        {
            var sortedByDescription = invoices.OrderByDescending(i => i.PartDescription).ThenBy(i => i.Quantity);
            foreach (var item in sortedByDescription)
            {
                Console.WriteLine($"Description: {item.PartDescription}\n Quantity: {item.Quantity}");
            }
        }

        static void Main(string[] args)
        {
            var selectedPrice = invoices.Select(i => (i.PartDescription, i.Quantity * i.Price)).OrderBy(i => i.PartDescription).ThenBy(i => i.Item2);
            foreach ((string desc, decimal value) item in selectedPrice)
            {
                Console.WriteLine($"Description: {item.desc} \n Value: {item.value}");
            }
        }
    }
}
