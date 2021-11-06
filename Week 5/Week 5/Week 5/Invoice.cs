﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_5
{
    public class Invoice
    {
        private int quantityValue;
        private decimal priceValue;

        public int PartNumber { get; set; }

        public string PartDescription { get; set; }

        public Invoice(int part, string description,
           int count, decimal pricePerItem)
        {
            PartNumber = part;
            PartDescription = description;
            Quantity = count;
            Price = pricePerItem;
        } // end constructor

        public int Quantity
        {
            get
            {
                return quantityValue;
            } // end get
            set
            {
                if (value > 0) // determine whether quantity is positive
                    quantityValue = value; // valid quantity assigned
            } // end set
        } // end property Quantity

        // property for pricePerItemValue; ensures value is positive
        public decimal Price
        {
            get
            {
                return priceValue;
            } // end get
            set
            {
                if (value >= 0M) // determine whether price is non-negative
                    priceValue = value; // valid price assigned
            } // end set
        } // end property Price

        // return string containing the fields in the Invoice in a nice format
        public override string ToString()
        {
            // left justify each field, and give large enough spaces so
            // all the columns line up
            return string.Format("{0,-5} {1,-20} {2,-5} {3,6:C}",
               PartNumber, PartDescription, Quantity, Price);
        } // end method ToString
    } //
}
