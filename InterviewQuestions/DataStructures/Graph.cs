using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.DataStructures
{
    public class Graph
    {
        /*
         *      A
         *     / \
         *    B   C
         *    \   /\
         *      D   E
         */
        public static GraphNode<char> MakeSampleGraph()
        {
            GraphNode<char> a = new GraphNode<char>('a');
            GraphNode<char> b = new GraphNode<char>('b');
            GraphNode<char> c = new GraphNode<char>('c');
            GraphNode<char> d = new GraphNode<char>('d');
            GraphNode<char> e = new GraphNode<char>('e');

            a.Neighbors = new GraphNode<char>[] { b, c };
            b.Neighbors = new GraphNode<char>[] { a, d };
            c.Neighbors = new GraphNode<char>[] { a, d, e };
            d.Neighbors = new GraphNode<char>[] { b, c };
            e.Neighbors = new GraphNode<char>[] { c };

            return a;
        }

        /*
         *  C - A - T
         *  R - E - S
         *  I - M - U
         */
        public static IEnumerable<GraphNode<char>> MakeCrosswordGraph()
        {
            GraphNode<char> g11 = new GraphNode<char>('C');
            GraphNode<char> g12 = new GraphNode<char>('A');
            GraphNode<char> g13 = new GraphNode<char>('T');
            GraphNode<char> g21 = new GraphNode<char>('R');
            GraphNode<char> g22 = new GraphNode<char>('E');
            GraphNode<char> g23 = new GraphNode<char>('S');
            GraphNode<char> g31 = new GraphNode<char>('I');
            GraphNode<char> g32 = new GraphNode<char>('M');
            GraphNode<char> g33 = new GraphNode<char>('U');

            g11.Neighbors = new GraphNode<char>[] { g12, g21 };
            g12.Neighbors = new GraphNode<char>[] { g11, g13, g22 };
            g13.Neighbors = new GraphNode<char>[] { g12, g23 };
            g21.Neighbors = new GraphNode<char>[] { g11, g22, g31 };
            g22.Neighbors = new GraphNode<char>[] { g12, g21, g23, g32 };
            g23.Neighbors = new GraphNode<char>[] { g13, g22, g33 };
            g31.Neighbors = new GraphNode<char>[] { g21, g32 };
            g32.Neighbors = new GraphNode<char>[] { g22, g31, g33 };
            g33.Neighbors = new GraphNode<char>[] { g23, g32 };

            GraphNode<char>[] nodes = new GraphNode<char>[]
            { g11, g12, g13, g21, g22, g23, g31, g32, g33 };

            return nodes;
        }
    }
}
