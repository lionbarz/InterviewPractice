using InterviewQuestions.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    /// <summary>
    /// Class for adding lines.
    /// </summary>
    public class LineAdder
    {
        /// <summary>
        /// Add two lines.
        /// </summary>
        /// <param name="a">First line as a series of points.</param>
        /// <param name="b">Second line as a series of points.</param>
        /// <returns>A line that is the sum of the first two lines.</returns>
        /// <remarks>
        /// Intermediate points are extrapolated to match points in the other line.
        /// Points on the edges that can't be extrapolated are ignored.
        /// </remarks>
        public static List<Point> AddLines(List<Point> a, List<Point> b)
        {
            if (a == null || a.Count == 0 || b == null || b.Count == 0)
            {
                return new List<Point>();
            }

            List<Point> sum = new List<Point>();

            Point lastA = null;
            Point lastB = null;
            int i = 0;
            int j = 0;

            while (i < a.Count && j < b.Count)
            {
                if (a[i].X == b[j].X)
                {
                    sum.Add(new Point()
                    {
                        X = a[i].X,
                        Y = a[i].Y + b[j].Y
                    });                 
                    lastA = a[i];
                    lastB = b[j];
                    i++;
                    j++;
                }
                else if (a[i].X < b[j].X)
                {
                    if (lastB != null)
                    {
                        double bPointY = MiddleValue(lastB, b[j], a[i].X);
                        sum.Add(new Point()
                        {
                            X = a[i].X,
                            Y = bPointY + a[i].Y
                        });
                    }
 
                    lastA = a[i];
                    i++;     
                }
                else
                {
                    if (lastA != null)
                    {
                        double aPointY = MiddleValue(lastA, a[i], b[j].X);
                        sum.Add(new Point()
                        {
                            X = b[j].X,
                            Y = aPointY + b[j].Y
                        });
                    }

                    lastB = b[j];
                    j++;
                }
            }

            return sum;
        }

        public static double MiddleValue(Point a, Point b, double x)
        {
            double slope = (b.Y - a.Y) / (b.X - a.X);
            return ((x - a.X) * slope) + a.Y;
        }
    }
}
