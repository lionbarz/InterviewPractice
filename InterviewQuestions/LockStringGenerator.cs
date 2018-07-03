using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    // There is a lock which accepts a 4-digit code, and you can keep typing
    // digits and it unlocks if the last four match. Task: generate the shortest
    // string which will open the lock. Hint: it will contain all possible 4-digit
    // combinations.
    //
    // Note: Made it a bit more generic so the digits can be from 0-<arbitrary number>
    public class LockStringGenerator
    {
        const int NumDigitsInCode = 2;

        // Try by generating all permutations. There are 10,000 unique codes.
        // The optimal string is of length 10,003 because the first code is of
        // length 4 and then each additional appended digit generates a new unique code, 
        // so 4 + 9,999 = 10,003.
        public static string GenerateString()
        {
            LinkedList<int> result = new LinkedList<int>();
            if (LockStringGenerator.GenerateString(result, new HashSet<int>()))
            {
                StringBuilder rval = new StringBuilder();
                foreach(int i in result)
                {
                    rval.Append(i);
                }
                return rval.ToString();
            }
            else
            {
                return null;
            }
        }

        private static bool GenerateString(LinkedList<int> soFar, HashSet<int> codes)
        {
            Console.WriteLine(soFar.Count);

            if (soFar.Count == (3 + Math.Pow(NumDigitsInCode, 4)))
            {
                return true;
            }

            if (soFar.Count < 3)
            {
                for (int i=0; i < LockStringGenerator.NumDigitsInCode; i++)
                {
                    soFar.AddLast(i);

                    if (LockStringGenerator.GenerateString(soFar, codes))
                    {
                        return true;
                    }

                    soFar.RemoveLast();
                }

                return false;
            }

            // We need to try tacking on all digits that give us new codes.
            for (int i=0; i < LockStringGenerator.NumDigitsInCode; i++)
            {
                int newCode = GetNewCode(soFar, i);
                if (!codes.Contains(newCode))
                {
                    codes.Add(newCode);
                    soFar.AddLast(i);
                    if (LockStringGenerator.GenerateString(soFar, codes))
                    {
                        return true;
                    }
                    soFar.RemoveLast();
                    codes.Remove(newCode);
                }
            }

            return false;
        }

        private static int GetNewCode(LinkedList<int> soFar, int i)
        {
            return (soFar.ElementAt(soFar.Count - 3) * 1000) +
                (soFar.ElementAt(soFar.Count - 2) * 100) +
                (soFar.ElementAt(soFar.Count - 1) * 10) +
                i;
        }
    }
}
