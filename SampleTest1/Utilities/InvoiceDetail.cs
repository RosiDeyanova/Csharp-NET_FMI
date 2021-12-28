using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class InvoiceDetail
    {
        private decimal dblLineTotal;

        public decimal DblLineTotal
        {
            get { return dblLineTotal; }
            set {
                if (value<0)
                {
                    dblLineTotal = 0;
                }
                else
                {
                    dblLineTotal = value;
                }
            }
        }

        public InvoiceDetail()
        {
            DblLineTotal = 0;
        }

        public override string ToString()
        {
            return String.Format("{0:F2}", DblLineTotal);
        }
    }
}
