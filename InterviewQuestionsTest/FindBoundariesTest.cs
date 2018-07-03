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
    public class FindBoundariesTest
    {
        [TestMethod]
        public void FindBoundaries()
        {
            Assert.AreEqual(
                new Tuple<int, int>(2, 5),
                BoundariesFinder.Find(new int[] { 0, 1, 2, 2, 2, 3, 4 }, 2));
            Assert.AreEqual(
                new Tuple<int, int>(0, 1),
                BoundariesFinder.Find(new int[] { 2 }, 2));
            Assert.AreEqual(
                new Tuple<int, int>(0, 2),
                BoundariesFinder.Find(new int[] { 2, 2 }, 2));
            Assert.AreEqual(
                new Tuple<int, int>(1, 3),
                BoundariesFinder.Find(new int[] { 1, 2, 2 }, 2));
        }
    }
}
