using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6
{
    public class Program
    {
        static void Main(string[] args)
        {
            Point point = new Point();
            Console.WriteLine(point);
            Rectangle rectangle = new Rectangle(10, 20, point);
            Console.WriteLine(rectangle);
            point.Coordinates = new[] { 100, 200 };
            Console.WriteLine(rectangle);
        }
    }
}
