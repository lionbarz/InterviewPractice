using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    /// <summary>
    /// In this problem, we want to find how to change one letter
    /// to get from an initial word to a final word.
    /// DOG
    /// DOT
    /// COT
    /// CAT
    /// </summary>
    public class ChangeLetter
    {
        private static HashSet<string> Dictionary = new HashSet<string>()
        {
            "CAB",
            "CAR",
            "CAT",
            "COT",
            "DOG",
            "FOG",
            "FOR",
            "DOT"
        };

        private class QueueNode
        {
            public string word;
            public QueueNode previous;
        }

        public static ICollection<string> FindProgression(string initial, string final)
        {
            initial = initial.ToUpper();
            final = final.ToUpper();

            HashSet<string> visited = new HashSet<string>();
            LinkedList<QueueNode> queue = new LinkedList<QueueNode>();
            queue.AddFirst(new QueueNode() { word = initial, previous = null });
            visited.Add(initial);
            
            while (queue.Count > 0)
            {
                QueueNode n = queue.First();
                queue.RemoveFirst();
                string word = n.word;
                Console.WriteLine("Processing " + word);

                for (int i=0; i < initial.Length; i++)
                {
                    for (int j=0; j < ('Z' - 'A'); j++)
                    {
                        char c = (char)('A' + j);
                        string newWord = word.Substring(0, i) + c + word.Substring(i + 1);

                        if (Dictionary.Contains(newWord) && !visited.Contains(newWord))
                        {
                            if (newWord.Equals(final))
                            {
                                LinkedList<string> progression = new LinkedList<string>();
                                progression.AddFirst(newWord);
                                progression.AddFirst(word);

                                while (n.previous != null)
                                {
                                    n = n.previous;
                                    progression.AddFirst(n.word);
                                }

                                return progression;
                            }

                            queue.AddLast(new QueueNode() { word = newWord, previous = n });
                            visited.Add(newWord);
                        }
                    }
                }
            }

            return null;
        }
    }
}
