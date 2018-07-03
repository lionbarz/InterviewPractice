using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewQuestions.DataStructures;

namespace InterviewQuestions
{
    public class LowestCommonAncestor<T>
    {
        public static T FindLca(TreeNode<T> node1, TreeNode<T> node2)
        {
            HashSet<TreeNode<T>> nodes = new HashSet<TreeNode<T>>();
            nodes.Add(node1);
            nodes.Add(node2);

            if (node1.Equals(node2))
            {
                return node1.Value;
            }

            TreeNode<T> current1 = node1;
            TreeNode<T> current2 = node2;

            while (current1.Parent != null || current2.Parent != null)
            {
                if (current1.Parent != null)
                {
                    if (nodes.Contains(current1.Parent))
                    {
                        return current1.Parent.Value;
                    }
                    else
                    {
                        nodes.Add(current1.Parent);
                        current1 = current1.Parent;
                    }
                }

                if (current2.Parent != null)
                {
                    if (nodes.Contains(current2.Parent))
                    {
                        return current2.Parent.Value;
                    }
                    else
                    {
                        nodes.Add(current2.Parent);
                        current2 = current2.Parent;
                    }
                }
            }

            return default(T);
        }
    }
}
