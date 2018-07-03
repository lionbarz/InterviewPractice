using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterviewQuestions;
using InterviewQuestions.DataStructures;
using InterviewQuestions.TreeAlgorithms;

namespace InterviewQuestionsTest
{
    [TestClass]
    public class BinarySearchTreeValidatorTest2
    {
        [TestMethod]
        public void TestIsValid()
        {
            BinarySearchTreeValidator2<int> validator = new BinarySearchTreeValidator2<int>();
            
            TreeNode<int> head = BinarySearchTree<int>.MakeSampleValidTree().Head;
            Assert.IsTrue(validator.IsValid(head));
            
            TreeNode<int> badHead = BinarySearchTree<int>.MakeSampleInvalidTree().Head;
            Assert.IsFalse(validator.IsValid(badHead));
        }
    }
}
