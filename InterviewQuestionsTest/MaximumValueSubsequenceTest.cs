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
    public class MaximumValueSubsequenceTest
    {
        [TestMethod]
        public void FindMaximumValueSubsequenceTest()
        {
            int i, j;
            double sum;

            MaximumValueSubsequence.FindMaximumValueSubsequence(
                new double[] { -2, 11, -4, 13, -5, 2 },
                out i,
                out j,
                out sum);

            Assert.AreEqual(20, sum);
        }
    }
}
