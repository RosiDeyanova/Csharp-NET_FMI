using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    public class Rectangle : Point
    {
        private Point lowerRightPoint;

        #region Constructors
        public Rectangle() : this(new Point(), new Point())
        {

        }

        public Rectangle(Point lowerRightPoint, Point upperRightPoint) : base(upperRightPoint)
        {
            LowerRightPoint = lowerRightPoint;
            UpperRightPoint = upperRightPoint;
        }

        public Rectangle(Rectangle rectangle) : this(rectangle.UpperRightPoint, rectangle.LowerRightPoint)
        {

        }

        #endregion

        public Point LowerRightPoint
        {
            get { return new Point(lowerRightPoint); }
            set { lowerRightPoint = value != null ? new Point(value) : new Point(); }
        }

        public Point UpperRightPoint
        {
            get { return new Point(base.Coordinates); }
            set { base.Coordinates = value != null ? value.Coordinates : new int[2]; }
        }

        public override string ToString()
        {
            return string.Format($"R: L={base.ToString()}, R={lowerRightPoint}");
        }

    }
}
