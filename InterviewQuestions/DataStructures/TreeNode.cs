using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.DataStructures
{
    public class TreeNode<T>
    {
        public T Value { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }
        public TreeNode<T> Parent { get; set; }

        public TreeNode(T value, TreeNode<T> left, TreeNode<T> right)
        {
            this.Value = value;
            this.Left = left;
            this.Right = right;
        }

        // Assume values are the IDs and are unique.
        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }

            TreeNode<T> other = obj as TreeNode<T>;

            if (other == null)
            {
                return false;
            }

            return other.Value.Equals(this.Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
