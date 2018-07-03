using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    // Given an array of sorted integers, find where one starts and ends.
    // Assumes the integer is there.
    // [0,1,2,2,2,3,4], 2 => 2,5
    public class BoundariesFinder
    {
        public static Tuple<int, int> Find(int[] input, int target)
        {
            return new Tuple<int, int>(
                BoundariesFinder.FindLeft(input, target, 0, input.Length),
                BoundariesFinder.FindRight(input, target, 0, input.Length));
        }

        private static int FindLeft(int[] input, int target, int i, int j)
        {
            int mid = (j - i) / 2 + i;

            // Can't check to the left.
            if (mid == 0)
            {
                return mid;
            }

            if (input[mid] == target && input[mid - 1] != target)
            {
                return mid;
            }
            else if (input[mid] == target || input[mid] > target)
            {
                // Answer is in the left half.
                return BoundariesFinder.FindLeft(input, target, i, mid);
            }
            else
            {
                // Answer is in right half.
                return BoundariesFinder.FindLeft(input, target, mid + 1, j);
            }
        }

        private static int FindRight(int[] input, int target, int i, int j)
        {
            int mid = (j - i) / 2 + i;

            if (mid + 1 == j)
            {
                return mid + 1;
            }

            if (input[mid] == target && input[mid + 1] != target)
            {
                return mid + 1;
            }
            else if (input[mid] == target || input[mid] < target)
            {
                // Answer is in the right half.
                return BoundariesFinder.FindRight(input, target, mid + 1, j);
            }
            else
            {
                // Answer is in left half.
                return BoundariesFinder.FindRight(input, target, 1, mid);
            }
        }
    }
}
