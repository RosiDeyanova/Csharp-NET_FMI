using System;
using System.Collections.Generic;
using Utilities;

namespace SampleTest1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            InvoiceDetail[] details = new InvoiceDetail[10];
            for (int i = 0; i < 10; i++)
            {
                details[i] = new InvoiceDetail();
                details[i].DblLineTotal = rnd.Next(0, 50);
            }

            Invoice in11 = new();
            in11.InvoiceItems = new InvoiceDetail[] { details[0] };
            IOutgoing in1 = in11;

            Invoice in21 = new();
            in21.InvoiceItems = new InvoiceDetail[] { details[1] };
            IReceivable in2 = in21;

            in11.AddAllInvoice(details);
            List<Invoice> MyInvoices = new List<Invoice>();

            //MyInvoices.Add(in1); (????)
        }
    }
}
