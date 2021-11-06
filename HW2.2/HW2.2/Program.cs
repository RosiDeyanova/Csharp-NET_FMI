using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2._2
{
    class Program
    {
        private static double Factoriel(double num)
        {
            double result = 1;
            while (num > 0)
            {
                result *= num;
                num--;
            }
            return result;
        }

        static void Main(string[] args)
        {
            var x = double.Parse(Console.ReadLine());
            var function = 0.0;
            for (int i = 0; i < 6; i++)
            {
                function += Math.Pow((-1), i) * ((Math.Pow(x, (2 * i)) / Factoriel(2 * i)));
            }

            var cos = Math.Cos(x);

            Console.WriteLine($"Function result: {function}\nCos result: {cos}");
        }
    }
}
