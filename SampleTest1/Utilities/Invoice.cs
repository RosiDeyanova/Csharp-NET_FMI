using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    static class IdGeneration
    {
        private static long id = 0;
        public static long GetID()
        {
            return id++;
        }
    }
    
    public class Invoice : IReceivable, IOutgoing
    {
        private long invoice_number;

        private InvoiceDetail[] invoiceItems;

        public InvoiceDetail[] InvoiceItems
        {
            get { return invoiceItems; }
            set {
                if (value.Length == 0)
                {
                    invoiceItems = new InvoiceDetail[0];
                }
                else
                {
                    invoiceItems = new InvoiceDetail[value.Length];
                    invoiceItems = value;
                }

            }
        }

        public long Invoice_number
        {
            get { return invoice_number; }
            set { invoice_number = IdGeneration.GetID(); }
        }

        decimal IReceivable.InvoiceTotal => InvoiceTotal();

        decimal IOutgoing.InvoiceTotal => (-1) * InvoiceTotal();

        public Invoice()
        {
            Invoice_number = 0;
            InvoiceItems = new InvoiceDetail[0];
        }

        public string InvoiceItemsString(InvoiceDetail[] invoiceDetails) 
        {
            string info = "No items";
            if (invoiceDetails.Length > 0)
            {
                info = "";
                for (int i = 0; i < invoiceDetails.Length - 1; i++)
                {
                    info += invoiceDetails[i];
                    info += ", ";
                }
                info += invoiceDetails[invoiceDetails.Length];

            }
            return info;
        }

        public decimal InvoiceTotal() 
        {
            decimal sum = 0;
            for (int i = 0; i < InvoiceItems.Length; i++)
            {
                sum += InvoiceItems[i].DblLineTotal;
            }
            return sum;
        }

        public static string PrintInvoices(List<Invoice> invoices) 
        {
            string info = "";
            for (int i = 0; i < invoices.Count; i++)
            {
                info += invoices[i].invoice_number + ": \n";
                invoices[i].InvoiceItems.OrderByDescending(i => i.DblLineTotal);
                foreach (var item in invoices[i].InvoiceItems)
                {
                    info += item.DblLineTotal + "\n";
                }
                info += invoices[i].InvoiceTotal();
                info += "\n";
            }
            return info;
        }

        public InvoiceDetail[] AddAllInvoice(InvoiceDetail[] invoiceDetails) 
        {
            InvoiceDetail[] newDetails = new InvoiceDetail[invoiceDetails.Length + InvoiceItems.Length];
            for (int i = 0; i < InvoiceItems.Length; i++)
            {
                newDetails[i] = InvoiceItems[i];
            }
            int k = 0;
            for (int i = InvoiceItems.Length; i < newDetails.Length; i++)
            {
                newDetails[i] = invoiceDetails[k];
                k++;
            }

            return newDetails;
        }

        public override string ToString()
        {
            return string.Format($"id: {invoice_number}, items: {InvoiceItemsString(InvoiceItems)}");
        }

        public override bool Equals(object obj)
        {
            if (InvoiceTotal() == ((Invoice)obj).InvoiceTotal())
            {
                return true;
            };
            return false;
        }
    }
}
