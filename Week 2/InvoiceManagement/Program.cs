using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Invoice invoice = new Invoice
            {
                Quantity = 100,
                PricePerItem = 100.0m
            };

            Console.WriteLine(invoice);
            Console.WriteLine($"Invoice amount: {invoice.GetInvoiceAmmount()}");
        }
    }
}
