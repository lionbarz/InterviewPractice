using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewQuestions.DataStructures;

namespace InterviewQuestions.TreeAlgorithms
{
    /// <summary>
    /// Validates a binary search tree using in-order traversal.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinarySearchTreeValidator2<T> where T : IComparable
    {
        private TreeNode<T> prev = null;

        public bool IsValid(TreeNode<T> head)
        {
            prev = null;
            return IsValidInternal(head);
        }

        private bool IsValidInternal(TreeNode<T> head)
        {
            if (head == null)
            {
                return true;
            }

            if (!IsValidInternal(head.Left))
            {
                return false;
            }
            
            if (prev != null && head.Value.CompareTo(prev.Value) < 0)
            {
                return false;
            }

            prev = head;

            return IsValidInternal(head.Right);
        }
    }
}
