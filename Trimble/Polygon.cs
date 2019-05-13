using System;
using System.Drawing;

namespace Trimble
{
    public class Polygon
    {
        private int[] Edges { get; }

        public Polygon(int[] edges, Point currentPoint)
        {
            Edges = edges;
        }

        public int GetArea()
        {
            Point previousPoint = Point.Empty;
            Point currentPoint = new Point(0, 0);
            var result = 0;

            foreach (var edge in Edges)
            {
                var nextPoint = GetNextPoint(edge, previousPoint, currentPoint);


                result += currentPoint.X * nextPoint.Y - currentPoint.Y * nextPoint.X;

                previousPoint = currentPoint;
                currentPoint = nextPoint;
            }

            return Math.Abs(result / 2);
        }

        private Point GetNextPoint(int edge, Point previousPoint, Point currentPoint)
        {
            var point = new Point(currentPoint.X, currentPoint.Y);

            if (currentPoint.Y > previousPoint.Y && edge > 0 ||
                currentPoint.Y < previousPoint.Y && edge < 0)
                point.X += Math.Abs(edge);
            else if (currentPoint.Y < previousPoint.Y && edge > 0 ||
                currentPoint.Y > previousPoint.Y && edge < 0)
                point.X -= Math.Abs(edge);
            else if (currentPoint.X > previousPoint.X && edge > 0 ||
                currentPoint.X < previousPoint.X && edge < 0)
                point.Y -= Math.Abs(edge);
            else if (currentPoint.X < previousPoint.X && edge > 0 ||
                currentPoint.X > previousPoint.X && edge < 0)
                point.Y += Math.Abs(edge);
            else point.X += Math.Abs(edge);

            return point;
        }
    }
}
