using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewQuestions.DataStructures;

namespace InterviewQuestions
{
    public class GraphSearch
    {
        public static char[] SearchBreadthFirst(GraphNode<char> node)
        {
            LinkedList<GraphNode<char>> queue = new LinkedList<GraphNode<char>>();
            HashSet<char> discovered = new HashSet<char>();
            LinkedList<char> found = new LinkedList<char>();

            queue.AddLast(node);
            discovered.Add(node.Value);

            while (queue.Count > 0)
            {
                GraphNode<char> curr = queue.First();
                queue.RemoveFirst();

                found.AddLast(curr.Value);

                foreach (GraphNode<char> neighbor in curr.Neighbors)
                {
                    if (!discovered.Contains(neighbor.Value))
                    {
                        queue.AddLast(neighbor);
                        discovered.Add(neighbor.Value);
                    }
                }
            }

            return found.ToArray();
        }

        public static List<List<char>> AllPaths(GraphNode<char> node)
        {
            List<List<char>> allPaths = new List<List<char>>();
            LinkedList<GraphNode<char>> path = new LinkedList<GraphNode<char>>();
            path.AddLast(node);
            GraphSearch.AllPaths(path, allPaths);
            return allPaths;
        }

        private static void AllPaths(LinkedList<GraphNode<char>> path, List<List<char>> allPaths)
        {
            GraphNode<char> curr = path.Last();

            bool deadEnd = true;

            foreach (GraphNode<char> neighbor in curr.Neighbors)
            {
                if (!path.Contains(neighbor))
                {
                    deadEnd = false;

                    path.AddLast(neighbor);
                    GraphSearch.AllPaths(path, allPaths);
                    path.RemoveLast();
                }
            }

            if (deadEnd)
            {
                List<char> charPath = new List<char>();

                foreach (GraphNode<char> node in path)
                {
                    charPath.Add(node.Value);
                }

                allPaths.Add(charPath);
            }
        }
    }
}
