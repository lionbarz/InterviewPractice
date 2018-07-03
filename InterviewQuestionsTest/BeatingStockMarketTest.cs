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
    public class BeatingStockMarketTest
    {
        [TestMethod]
        public void TestFind()
        {
            Assert.AreEqual(new Tuple<int, int>(2, 3), BeatingStockMarket.Find(new int[] { 5, 10, 0, 8 }));
            Assert.AreEqual(new Tuple<int, int>(0, 3), BeatingStockMarket.Find(new int[] { 5, 10, 15, 30 }));
        }
    }
}
