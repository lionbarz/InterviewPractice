using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.DynamicProgramming
{
    /// <summary>
    /// Make change with the fewest number of coins.
    /// </summary>
    public class ChangeMaker
    {
        // Matrix of lists of the change for each amount and coins allowed.
        private LinkedList<int>[][] matrix;

        public ChangeMaker(int maxChange, int[] coins)
        {
            Array.Sort(coins);

            if (coins[0] != 1)
            {
                throw new Exception("Must have a 1 value coin to make change for any value.");
            }

            matrix = new LinkedList<int>[maxChange][];

            for (int i=0; i < maxChange; i++)
            {
                matrix[i] = new LinkedList<int>[coins.Count()];
            }

            for (int i=0; i < coins.Count(); i++)
            {
                matrix[0][i] = new LinkedList<int>();
            }

            for (int i=1; i < maxChange; i++)
            {
                LinkedList<int> list = new LinkedList<int>();

                for (int j = 0; j < i; j++)
                {
                    list.AddLast(1);
                }

                matrix[i][0] = list;
            }

            for (int i=1; i < maxChange; i++)
            {
                for (int j=1; j < coins.Count(); j++)
                {
                    if (coins[j] > i)
                    {
                        // Can't use this coin.
                        matrix[i][j] = matrix[i][j-1];
                    }
                    else
                    {
                        int coinValue = coins[j];
                        bool useCoin = (1 + matrix[i - coinValue][j].Count()) < matrix[i][j - 1].Count();
                        
                        if (useCoin)
                        {
                            LinkedList<int> newList = new LinkedList<int>();

                            foreach (int val in matrix[i - coinValue][j])
                            {
                                newList.AddLast(val);
                            }

                            newList.AddLast(coinValue);
                            matrix[i][j] = newList;
                        }
                        else
                        {
                            matrix[i][j] = matrix[i][j - 1];
                        }
                    }
                }
            }
        }

        public IEnumerable<int> MakeChange(int change)
        {
            if (change >= matrix.Count())
            {
                throw new Exception("Change {0} is too much!");
            }

            return matrix[change][matrix[change].Count()-1];
        }
    }
}
