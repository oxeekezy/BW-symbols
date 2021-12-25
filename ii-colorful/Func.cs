using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ii_colorful
{
    internal class Func
    {
        string name;
        Line left;
        Line right;

        public Func(string name,Point p1, Point p2, Point p3) 
        {
            this.name = name;
            left = new Line(p1,p2);
            right = new Line(p2,p3);
        }

        public double CalsY(double x) 
        {
            double k = 0;
            double b = 0;

            if (x <= left.end.X)
            {
                k = (left.end.Y - left.start.Y) / (left.end.X - left.start.X);
                b = left.start.Y - k * left.start.X;
            }
            else 
            {
                k = (right.end.Y - right.start.Y) / (right.end.X - right.start.X);
                b = right.start.Y - k * right.start.X;
            }

            double res = k * x + b;

            if (res < 0)
                return 0;
            else
                return Math.Round(res,2);
        }
    }
}
