using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    public class Table
    {
        #region Fields
        private double statingValue;
        private double endingValue;
        private int valuesPerRow;
        #endregion

        #region Constructor
        public Table()
        {
            StartingValue = 0;
            EndingValue = 0;
            ValuesPerRow = 1;
        }
        #endregion

        #region Properties
        public int ValuesPerRow
        {
            get { return valuesPerRow; }
            set { valuesPerRow = value > 0 ? value : 1; }
        }

        public double EndingValue
        {
            get { return endingValue; }
            set { endingValue = value; }
        }

        public double StartingValue
        {
            get { return statingValue; }
            set { statingValue = value; }
        }

        #endregion

        #region Methods

        public void MakeTable()
        {
            var x = StartingValue;
            for (int i = 0; i < valuesPerRow; i++)
            {
                double function = Math.Pow((Math.Abs(x - 2)), 2) / ((Math.Pow(x, 2)) + 1);
                Console.Write("{0:F4}", function);
                Console.Write(" ");
                if (i>0 && i % 20 == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Press return to continue");
                    var returnWord = Console.ReadLine();
                    if (returnWord.ToLower() == "return")
                    {
                        Console.WriteLine();
                    }
                    else
                    {
                        return;
                    }
                }
                x += GetDistanceBetweenSteps(StartingValue, EndingValue, ValuesPerRow);
            }
        }

        public double GetDistanceBetweenSteps(double startingValue, double endingValue, int valuesPerRow)
        {
            double wholeNumbers = endingValue - startingValue + 1;

            return wholeNumbers / valuesPerRow; //gets the distance between the steps so the steps will be with equal intervals
        }

        #endregion    
    }
}
