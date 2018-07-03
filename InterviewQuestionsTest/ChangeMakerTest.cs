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
    public class ChangeMakerTest
    {
        [TestMethod]
        public void TestMakeChange()
        {
            ChangeMaker maker = new ChangeMaker(100, new int[] { 1, 5, 10, 25 });
            IEnumerable<int> change = maker.MakeChange(41);
            Assert.IsTrue(change.SequenceEqual(new int[] { 1, 5, 10, 25 }));
            change = maker.MakeChange(75);
            Assert.IsTrue(change.SequenceEqual(new int[] { 25, 25, 25 }));
            change = maker.MakeChange(1);
            Assert.IsTrue(change.SequenceEqual(new int[] { 1 }));
            change = maker.MakeChange(99);
            Assert.IsTrue(change.SequenceEqual(new int[] { 1, 1, 1, 1, 10, 10, 25, 25, 25 }));
        }
    }
}
