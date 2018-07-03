using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.DynamicProgramming
{
    public class LongestIncreasingSubsequence
    {
        public static IEnumerable<int> FindLongestIncreasingSubsequence(int[] sequence)
        {
            if (sequence.Length == 0)
            {
                return new List<int>();
            }

            int[] lengths = new int[sequence.Length];
            int[] prev = new int[sequence.Length];

            lengths[0] = 1;
            prev[0] = -1;

            for (int i=1; i<sequence.Length; i++)
            {
                int maxLength = 0;
                int maxEnd = -1;

                for (int j=0; j < i; j++)
                {
                    if (sequence[j] < sequence[i])
                    {
                        if (lengths[j] > maxLength)
                        {
                            maxLength = lengths[j];
                            maxEnd = j;
                        }
                    }
                }

                if (maxLength > 0)
                {
                    lengths[i] = maxLength + 1;
                    prev[i] = maxEnd;
                }
                else
                {
                    lengths[i] = 1;
                    prev[i] = -1;
                }
            }

            int length = 1;
            int index = 0;

            for (int i=1; i<lengths.Length; i++)
            {
                if (lengths[i] > length)
                {
                    length = lengths[i];
                    index = i;
                }
            }

            LinkedList<int> subsequence = new LinkedList<int>();
            subsequence.AddFirst(sequence[index]);

            while (prev[index] != -1)
            {
                index = prev[index];
                subsequence.AddFirst(sequence[index]);
            }

            return subsequence;
        }
    }
}
