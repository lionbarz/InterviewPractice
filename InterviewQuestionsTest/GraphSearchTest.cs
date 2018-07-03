using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterviewQuestions;
using InterviewQuestions.DataStructures;

namespace InterviewQuestionsTest
{
    [TestClass]
    public class GraphSearchTest
    {
        [TestMethod]
        public void SearchBreadthFirstTest()
        {
            CollectionAssert.AreEqual(
                new char[] { 'a', 'b', 'c', 'd', 'e' },
                GraphSearch.SearchBreadthFirst(Graph.MakeSampleGraph()));
        }

        [TestMethod]
        public void AllPathsTest()
        {
            List<List<char>> paths = GraphSearch.AllPaths(Graph.MakeSampleGraph());
            Assert.AreEqual(3, paths.Count);
        }
    }
}
