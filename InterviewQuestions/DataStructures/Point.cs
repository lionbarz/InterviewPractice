using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.DataStructures
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public override bool Equals(object obj)
        {
            Point p = obj as Point;
            
            if (p == null)
            {
                return false;
            }

            return p.X == X && p.Y == Y;
        }

        public override int GetHashCode()
        {
            return (int)X ^ (int)Y;
        }
    }
}
