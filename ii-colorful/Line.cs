using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ii_colorful
{
    internal class Line
    {
        public Point start;
        public Point end;

        public Line(Point start, Point end) 
        {
            this.start = start;
            this.end = end;
        }
    }
}
