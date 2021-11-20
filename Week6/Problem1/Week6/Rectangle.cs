using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6
{
    public class Rectangle
    {
        #region Fields
        public delegate double CompareBy(Rectangle r);
        private static readonly char[] indexes = new[] { 'x', 'y', 'w', 'h' };
        public readonly string R_ID;
        private static int cntID = 1;
        private double lenght;
        private double width;
        private Point leftPoint;
        #endregion

        #region Constructors
        public Rectangle(double lenght, double width, Point leftPoint)
        {
            Lenght = lenght;
            Width = width;
            LeftPoint = leftPoint;
            R_ID = string.Format($"{cntID++:D6}");
        }

        public Rectangle() : this(0, 0, new Point())
        {

        }

        public Rectangle(Rectangle r) : this(r.lenght, r.width, r.leftPoint)
        { } 
        #endregion

        #region Properties
        public Point LeftPoint
        {
            get
            {
                return new Point(leftPoint);
            }
            set
            {
                leftPoint = value != null ? new Point(value) : new Point();
            }
        }

        public double Width
        {
            get { return width; }
            set { width = value >= 0 ? value : 0; }
        }

        public double Lenght
        {
            get { return lenght; }
            set { lenght = value >= 0 ? value : 0; }
        }

        public object this[char index]
        {
            get {
                if (indexes.Contains(index))
                {
                    switch (index)
                    {
                        case 'w': return width;
                        case 'l': return lenght;
                        case 'x': return leftPoint['x']; 
                        case 'y': return leftPoint['y']; 
                    }
                }
                return double.MaxValue;
            }
            set {
                if (indexes.Contains(index))
                {
                    switch (index)
                    {
                        case 'w': width = value >= 0 ? value : 0; break;
                        case 'l': lenght = value >= 0 ? value : 0; break;
                        case 'x': leftPoint['x'] = value; break;
                        case 'y': leftPoint['y'] = value; break;
                    }
                }
            }
        }


        public static double Area(Rectangle r) 
        {
            return r.lenght * r.width;
        }

        public static IEnumerable<Rectangle> SortBy(List<Rectangle> list, CompareBy compare) 
        {
            var sorted = list.OrderBy(r => compare(r));
            return sorted;
        }

        #endregion

        public override string ToString()
        {
            return string.Format($"Rectangle {R_ID}: W = {width}, L = {lenght}, LP = {leftPoint}");
        }
    }
}
