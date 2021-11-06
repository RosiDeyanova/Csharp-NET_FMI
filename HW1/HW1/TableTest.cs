using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    public class TableTest
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter first point:");
            double inputStartingValue = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter second point:");
            double inputEndingValue = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter number of steps:");

            Table table = new Table
            {
                ValuesPerRow = int.Parse(Console.ReadLine()),
                StartingValue = Math.Min(inputStartingValue, inputEndingValue),
                EndingValue = Math.Max(inputStartingValue, inputEndingValue)
            };

            table.MakeTable();

        }


    }
}

