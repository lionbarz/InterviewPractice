using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterviewQuestions;
using InterviewQuestions.TreeAlgorithms;
using InterviewQuestions.DataStructures;

namespace InterviewQuestionsTest
{
    [TestClass]
    public class BinarySearchTreeValidatorTest
    {
        [TestMethod]
        public void TestIsValid()
        {
            Assert.IsTrue(BinarySearchTreeValidator.IsValid(BinarySearchTree<int>.MakeSampleValidTree().Head));
            Assert.IsFalse(BinarySearchTreeValidator.IsValid(BinarySearchTree<int>.MakeSampleInvalidTree().Head));
        }
    }
}
