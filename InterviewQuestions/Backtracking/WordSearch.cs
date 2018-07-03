using InterviewQuestions.DataStructures;
using InterviewQuestions.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Backtracking
{
    public class WordSearch
    {
        public static ICollection<string> FindWords(IEnumerable<GraphNode<char>> board)
        {
            ICollection<string> words = new LinkedList<string>();
            foreach(GraphNode<char> node in board)
            {
                FindWords(node, words, new HashSet<GraphNode<char>>() { node }, new StringBuilder(node.Value.ToString()));
            }
            return words;
        }

        public static void FindWords(
            GraphNode<char> node,
            ICollection<string> words,
            HashSet<GraphNode<char>> visited,
            StringBuilder word)
        {
            if (EnglishDictionary.IsWord(word.ToString()))
            {
                words.Add(word.ToString());
            }

            foreach (GraphNode<char> neighbor in node.Neighbors)
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    word.Append(neighbor.Value);
                    FindWords(neighbor, words, visited, word);
                    visited.Remove(neighbor);
                    word.Remove(word.Length - 1, 1);
                }
            }
        }
    }
}
