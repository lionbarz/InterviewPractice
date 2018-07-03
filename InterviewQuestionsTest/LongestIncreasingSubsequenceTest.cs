using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterviewQuestions.DynamicProgramming;

namespace InterviewQuestionsTest
{
    [TestClass]
    public class LongestIncreasingSubsequenceTest
    {
        [TestMethod]
        public void TestFindLongestIncreasingSubsequence()
        {  
            IEnumerable<int> sub = LongestIncreasingSubsequence.FindLongestIncreasingSubsequence(
                new int[] { 0, 8, 4, 12, 2, 10, 6, 14, 1, 9, 5, 13, 3, 11, 7, 15 });

            Assert.AreEqual(6, sub.Count());

            Assert.IsTrue(sub.SequenceEqual(new int[] { 0, 2, 6, 9, 11, 15 }) ||
                sub.SequenceEqual(new int[] { 0, 4, 6, 9, 11, 15 }) ||
                sub.SequenceEqual(new int[] { 0, 4, 6, 9, 13, 15 }));
        }
    }
}
