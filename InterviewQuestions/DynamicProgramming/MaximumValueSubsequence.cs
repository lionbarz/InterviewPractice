using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.DynamicProgramming
{
    /// <summary>
    /// Given a sequence of n real numbers A(0)...A(n-1),
    /// determine a contiguous subsequence A(i) ... A(j)
    /// for which the sum of elements in the subsequence
    /// is maximized.
    /// </summary>
    public class MaximumValueSubsequence
    {
        public static void FindMaximumValueSubsequence(
            IEnumerable<double> list,
            out int i,
            out int j,
            out double sum)
        {
            int n = list.Count();

            if (n == 0)
            {
                i = -1;
                j = -1;
                sum = -1;
                return;
            }

            // sums[j] = Max sum over all windows ending at j
            double[] sums = new double[n];

            i = 0;
            j = 0;
            int m = 0;

            foreach (double val in list)
            {
                if (m == 0)
                {
                    sums[0] = val;
                }
                else
                {
                    // Either we extend the optimal window ending at
                    // val or start a fresh window with val.
                    sums[m] = Math.Max(sums[m - 1] + val, val);
                }

                m++;
            }

            sum = sums.Max();
        }
    }
}
