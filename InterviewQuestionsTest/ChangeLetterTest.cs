using InterviewQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestionsTest
{
    [TestClass]
    public class ChangeLetterTest
    {
        [TestMethod]
        public void FindProgressionTest()
        {
            ICollection<string> words = ChangeLetter.FindProgression("DOG", "CAT");
            Assert.IsTrue(words.SequenceEqual(new List<string>() { "DOG", "DOT", "COT", "CAT" }));
        }
    }
}
