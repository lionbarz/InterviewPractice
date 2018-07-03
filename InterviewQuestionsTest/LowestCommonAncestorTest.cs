using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterviewQuestions;
using InterviewQuestions.DataStructures;

namespace InterviewQuestionsTest
{
    [TestClass]
    public class LowestCommonAncestorTest
    {
        [TestMethod]
        public void TestLca()
        {
            BinarySearchTree<int> tree = BinarySearchTree<int>.MakeSampleValidTree();
            Assert.AreEqual(6, LowestCommonAncestor<int>.FindLca(tree.Find(3), tree.Find(15)));
            Assert.AreEqual(17, LowestCommonAncestor<int>.FindLca(tree.Find(1), tree.Find(48)));
            Assert.AreEqual(17, LowestCommonAncestor<int>.FindLca(tree.Find(17), tree.Find(48)));
        }
    }
}
