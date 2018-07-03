using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InterviewQuestionsTest
{
    [TestClass]
    public class FizzBuzzTest
    {
        [TestMethod]
        public void DoItTest()
        {
            FizzBuzz fizzBuzz = new FizzBuzz();
            IList<string> results = fizzBuzz.DoIt();
            Assert.AreEqual("1", results[0]);
            Assert.AreEqual("Fizz", results[2]);
            Assert.AreEqual("Buzz", results[4]);
            Assert.AreEqual("FizzBuzz", results[14]);
            Assert.AreEqual("Fizz", results[20]);
            Assert.AreEqual("23", results[22]);
            Assert.AreEqual("Buzz", results[19]);
            Assert.AreEqual("FizzBuzz", results[29]);
            Assert.AreEqual("Buzz", results[99]);
        }

    }
}
