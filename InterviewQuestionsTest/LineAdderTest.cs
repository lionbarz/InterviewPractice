using InterviewQuestions;
using InterviewQuestions.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestionsTest
{
    [TestClass]
    public class LineAdderTest
    {
        [TestMethod]
        public void AddLinesTest()
        {
            List<Point> a = new List<Point>()
            {
                new Point()
                {
                    X = 0,
                    Y = 0
                },
                new Point()
                {
                    X = 2,
                    Y = 2
                },
                new Point()
                {
                    X = 4,
                    Y = 0
                }
            };
            List<Point> b = new List<Point>()
            {
                new Point()
                {
                    X = 1,
                    Y = 2
                },
                new Point()
                {
                    X = 2,
                    Y = 2
                },
                new Point()
                {
                    X = 3,
                    Y = 2
                }
            };
            List<Point> expectedSum = new List<Point>()
            {
                new Point()
                {
                    X = 1,
                    Y = 3
                },
                new Point()
                {
                    X = 2,
                    Y = 4
                },
                new Point()
                {
                    X = 3,
                    Y = 3
                }
            };
            List<Point> sum = LineAdder.AddLines(a, b);
            CollectionAssert.AreEqual(expectedSum, sum);
        }

        [TestMethod]
        public void MiddleValueTest()
        {
            double y = LineAdder.MiddleValue(
                new Point()
                {
                    X = 0,
                    Y = 0
                },
                new Point()
                {
                    X = 4,
                    Y = 4
                },
                2);
            Assert.AreEqual(2, y);
        }
    }
}
