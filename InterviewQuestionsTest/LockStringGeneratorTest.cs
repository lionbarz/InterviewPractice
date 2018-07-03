using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterviewQuestions;

namespace InterviewQuestionsTest
{
    [TestClass]
    public class LockStringGeneratorTest
    {
        [TestMethod]
        public void TestGenerator()
        {
            Assert.AreNotEqual(null, LockStringGenerator.GenerateString());
        }
    }
}
