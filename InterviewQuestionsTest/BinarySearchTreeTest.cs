using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewQuestions.DataStructures;

namespace InterviewQuestionsTest
{
    [TestClass]
    public class BinarySearchTreeTest
    {
        [TestMethod]
        public void TestBinarySearchTreeToList()
        {
            BinarySearchTree<int> tree = BinarySearchTree<int>.MakeSampleValidTree();
            IEnumerable<int> list = tree.ToList();
            List<int> expected = new List<int>() { 1, 3, 6, 9, 12, 15, 17, 46, 48, 56 };
            Assert.IsTrue(list.SequenceEqual(expected));
        }

        [TestMethod]
        public void TestBinarySearchTreeFromList()
        {
            List<int> list = new List<int>() { 1, 3, 6, 9, 12, 15, 17, 46, 48, 56 };
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.FromList(list);
            Assert.IsTrue(list.SequenceEqual(tree.ToList()));
        }
    }
}
