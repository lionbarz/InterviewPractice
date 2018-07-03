using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterviewQuestions.DataStructures;
using InterviewQuestions.Backtracking;

namespace InterviewQuestionsTest
{
    [TestClass]
    public class WordSearchTest
    {
        [TestMethod]
        public void FindWordsTest()
        {
            IEnumerable<GraphNode<char>> board = Graph.MakeCrosswordGraph();
            ICollection<string> words = WordSearch.FindWords(board);
            Assert.IsTrue(words.Contains("CAT"));
            Assert.IsTrue(words.Contains("CRIME"));
        }
    }
}
