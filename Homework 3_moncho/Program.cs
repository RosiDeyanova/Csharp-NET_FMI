using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_3
{
    class Program
    {
        static void Main(string[] args)
        {
            RouteCipher test = new RouteCipher(3);
            String m = "MONCHOISTHEBESTTHEREIS";
            String result = test.encrypt(m);
            Console.WriteLine(result);
            String result2 = test.decrypt(result);
            Console.WriteLine(result2);
        }
    }
}
