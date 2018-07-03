using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewQuestions.DataStructures;

namespace InterviewQuestions.TreeAlgorithms
{
    /// <summary>
    /// Validates a search tree by carrying a min and max value and
    /// recursing on the left and right subtrees.
    /// </summary>
    public class BinarySearchTreeValidator
    {
        public static bool IsValid(TreeNode<int> head)
        {
            return BinarySearchTreeValidator.IsValid(head, int.MinValue, int.MaxValue);
        }

        public static bool IsValid(TreeNode<int> node, int min, int max)
        {
            if (node == null)
            {
                return true;
            }

            if (node.Value > max || node.Value <= min)
            {
                return false;
            }

            if (node.Left != null)
            {
                if (!BinarySearchTreeValidator.IsValid(node.Left, min, node.Value))
                {
                    return false;
                }
            }

            if (node.Right != null)
            {
                if (!BinarySearchTreeValidator.IsValid(node.Right, node.Value, max))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
