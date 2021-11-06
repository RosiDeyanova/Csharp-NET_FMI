using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagement
{
    public class Invoice
    {
        #region Fields
        private string partDescription;
        private string partNumber;
        private decimal pricePerItem;
        private double quantity;

        #endregion

        #region Constructors
        public Invoice()
        {
            PartDescription = "No part description";
            PartNumber = "No part number";
            PricePerItem = 1;
            Quantity = 0;
        }

        public Invoice(string partDescription, string partNumber, decimal pricePerItem, double quantity)
        {
            PartNumber = partNumber;
            PartDescription = partDescription;
            PricePerItem = pricePerItem;
            Quantity = quantity;
        }

        public Invoice(Invoice invoice)
        {
            PartDescription = invoice.PartDescription;
            PartNumber = invoice.PartNumber;
            PricePerItem = invoice.PricePerItem;
            Quantity = invoice.Quantity;
        }
        #endregion 

        #region Properties
        public double Quantity
        {
            get { return quantity; }
            set { quantity = value >= 0 ? value : 0; }
        }


        public decimal PricePerItem
        {
            get { return pricePerItem; }
            set { pricePerItem = value > 0 ? value : 1; }
        }


        public string PartNumber
        {
            get { return partNumber; }
            set { partNumber = value != null ? value : "No part number"; }
        }


        public string PartDescription
        {
            get { return partDescription; }
            set { partDescription = value != null ? value : "No description"; }
        }

        #endregion

        public decimal GetInvoiceAmmount() 
        {
            return pricePerItem * (decimal)quantity;
        }

        public override string ToString()
        {
            string result = $"Price per Item: {PricePerItem}\nQuantity: {Quantity}";
            return result;
        }
    }
}
