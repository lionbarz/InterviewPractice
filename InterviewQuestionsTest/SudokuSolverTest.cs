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
    public class SudokuSolverTest
    {
        [TestMethod]
        public void TestSolve()
        {
            SudokuSolver.SudokuBoard board = new SudokuSolver.SudokuBoard();
            SudokuSolver.Solve(board);
            Assert.IsTrue(board.IsValid());
        }
    }
}
