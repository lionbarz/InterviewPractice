using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewQuestions.DataStructures;

namespace InterviewQuestions
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<List<char>> paths = GraphSearch.AllPaths(Graph.MakeSampleGraph());
            SudokuSolver.SudokuBoard board = new SudokuSolver.SudokuBoard();
            SudokuSolver.Solve(board);
            Console.WriteLine(board);
        }
    }
}
