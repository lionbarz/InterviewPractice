using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.DataStructures
{
    public class BinarySearchTree<T> where T : IComparable
    {
        public TreeNode<T> Head { get; private set; }
        
        /// <summary>
        ///                        17
        ///                       /  \
        ///                      6     46
        ///                     /\      \
        ///                    3  12     56
        ///                   /   /\      /
        ///                  1   9  15   48
        /// </summary>
        /// <returns></returns>
        public static BinarySearchTree<int> MakeSampleValidTree()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Insert(17);
            tree.Insert(46);
            tree.Insert(56);
            tree.Insert(48);
            tree.Insert(6);
            tree.Insert(3);
            tree.Insert(12);
            tree.Insert(1);
            tree.Insert(9);
            tree.Insert(15);
            return tree;
        }

        /// <summary>
        ///                        17
        ///                       /  \
        ///                      6    8  
        /// </summary>
        /// <returns></returns>
        public static BinarySearchTree<int> MakeSampleInvalidTree()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Insert(17);
            tree.Insert(6);
            tree.Head.Right = new TreeNode<int>(8, null, null); 
            return tree;
        }

        public TreeNode<T> Find(T value)
        {
            return Find(value, this.Head);
        }

        public void Insert(T value)
        {
            if (this.Head == null)
            {
                this.Head = new TreeNode<T>(value, null, null);
            }
            else
            {
                this.Insert(value, this.Head);
            }
        }

        public IEnumerable<T> ToList()
        {
            LinkedList<T> list = new LinkedList<T>();
            ToList(Head, list);
            return list;
        }

        public void FromList(List<T> list)
        {
            Head = FromList(list, 0, list.Count-1);
        }

        /// <summary>
        /// Make a BST tree from a sorted list by inserting
        /// recursively from the middle.
        /// </summary>
        /// <param name="list">List of elements.</param>
        /// <param name="i">Start index inclusive.</param>
        /// <param name="j">End index inclusive.</param>
        /// <returns>The head of the tree.</returns>
        private TreeNode<T> FromList(List<T> list, int i, int j)
        {
            if (i > j)
            {
                return null;
            }

            if (i == j)
            {
                return new TreeNode<T>(list[i], null, null);
            }

            int m = i + (j - i) / 2;

            TreeNode<T> n = new TreeNode<T>(list[m], null, null);

            n.Left = FromList(list, i, m - 1);
            n.Right = FromList(list, m + 1, j);

            return n;
        }

        private void ToList(TreeNode<T> head, LinkedList<T> list)
        {
            if (head == null)
            {
                return;
            }

            ToList(head.Left, list);
            list.AddLast(head.Value);
            ToList(head.Right, list);
        }

        private TreeNode<T> Find(T value, TreeNode<T> node)
        {
            if (node.Value.CompareTo(value) == 0)
            {
                return node;
            }
            else if (value.CompareTo(node.Value) < 0)
            {
                if (node.Left == null)
                {
                    return null;
                }
                else
                {
                    return Find(value, node.Left);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    return null;
                }
                else
                {
                    return Find(value, node.Right);
                }
            }
        }

        private void Insert(T value, TreeNode<T> node)
        {
            if (value.CompareTo(node.Value) <= 0)
            {
                if (node.Left == null)
                {
                    node.Left = new TreeNode<T>(value, null, null);
                    node.Left.Parent = node;
                }
                else
                {
                    this.Insert(value, node.Left);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new TreeNode<T>(value, null, null);
                    node.Right.Parent = node;
                }
                else
                {
                    this.Insert(value, node.Right);
                }
            }
        }
    }
}
