using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LeaderWithRealSense
{
    public class RoutePoint
    {
        public string ID;
        public double X;
        public double Y;
        public double Z;
        public double RX;
        public double RY;
        public double RZ;

        public double shiftX;
        public double shiftY;
        public double shiftZ;
        public double shiftA;
        public double shiftB;
        public double shiftC;


        public int NormalizationX;
        public int NormalizationY;
        public int NormalizationZ;

        public RoutePoint Prev;
        public RoutePoint Next;

        private Point linePointNew;
        public Point LinePoint
        {
            get { return linePointNew; }
        }
        public void LinePointUpdata(int x, int y, double s)
        {
            double linePointOrigonX = x + 20;
            double linePointOrigonY = y;
            double sinda = -s * Math.PI / 180;
            double newX = Math.Cos(sinda) * x - Math.Sin(sinda) * y;
            double newY = Math.Sin(sinda) * x + Math.Cos(sinda) * y;
            int rotationX = (int)Math.Round(Math.Abs(newX - x));
            int rotationY = (int)Math.Round(Math.Abs(newY - y));

            linePointNew.X = (int)Math.Round(Math.Cos(sinda) * linePointOrigonX - Math.Sin(sinda) * linePointOrigonY);
            linePointNew.Y = (int)Math.Round(Math.Sin(sinda) * linePointOrigonX + Math.Cos(sinda) * linePointOrigonY);

            if (newX > x)
            {
                linePointNew.X = linePointNew.X - rotationX;
            }
            else
            {
                linePointNew.X = linePointNew.X + rotationX;
            }
            if (newY > y)
            {
                linePointNew.Y = linePointNew.Y - rotationY;
            }
            else
            {
                linePointNew.Y = linePointNew.Y + rotationY;
            }
        }

    }
}
