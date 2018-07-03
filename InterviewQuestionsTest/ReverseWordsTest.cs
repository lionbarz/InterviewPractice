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
    public class ReverseWordsTest
    {
        [TestMethod]
        public void TestReverse()
        {
            Assert.AreEqual("you, are, how Mo Hi?", ReverseWords.Reverse("Hi, Mo, how are you?"));
            Assert.AreEqual("Mo", ReverseWords.Reverse("Mo"));
            Assert.AreEqual(string.Empty, string.Empty);
        }

        [TestMethod]
        public void TestReverseInPlace()
        {
            Assert.AreEqual("you are how Mo Hi", ReverseWords.ReverseInPlace("Hi Mo how are you"));
            Assert.AreEqual("Mo", ReverseWords.ReverseInPlace("Mo"));
            Assert.AreEqual(" ", ReverseWords.ReverseInPlace(" "));
            Assert.AreEqual(string.Empty, string.Empty);
        }
    }
}
