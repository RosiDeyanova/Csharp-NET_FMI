using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4
{
    class Product
    {
        #region Fields
        private long cnt = 0;
        private Random rnd = new Random();
        public string ID;
        public List<int> WeeklyPurchases;
        #endregion

        #region Properties
        public Type Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public YearlyQuarter Quarter { get; set; }
        #endregion 

        private static int GenerateYearlyQuarter(Random rnd) 
        {
            return rnd.Next(0, 4);
        }

        private static string GenerateIDNumber(Random rnd, long cnt) 
        {
            cnt = rnd.Next(0, 100000);
            var numString = cnt.ToString();
            for (int i = 0; i < 6-numString.Length; i++)
            {
                numString = '0' + numString;
            }
            return numString;
        }

        public Product()
        {
            Description = "no description entered";
            Category = (Type)0;
            WeeklyPurchases = null;
            Price = 0;
            Quarter = (YearlyQuarter)GenerateYearlyQuarter(rnd);
            ID = Category + "0";
        }

        public Product(string desc, Type categ, List<int> weeklypurch, decimal price)
        {
            Description = desc;
            Category = categ;
            WeeklyPurchases = weeklypurch;
            Price = price;
            Quarter = (YearlyQuarter)GenerateYearlyQuarter(rnd);
            ID = Category + GenerateIDNumber(rnd, cnt);
        }
    }
}
