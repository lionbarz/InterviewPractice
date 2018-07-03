using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    /// <summary>
    /// Fills in all the blank (zero) spaces in a sudoku board
    /// using backtracking.
    /// </summary>
    public class SudokuSolver
    {
        public class SudokuSquare
        {
            public int[] Values { get; set; }

            public SudokuSquare()
            {
                this.Values = new int[9];
            }

            public bool IsValidValue(int index, int value)
            {
                for (int i=0; i<9; i++)
                {
                    if (i != index && this.Values[i] == value)
                    {
                        return false;
                    }
                }

                return true;
            }

            /// <summary>
            /// Checks if the value makes the square row invalid
            /// by introducing a duplicate in that row.
            /// </summary>
            /// <param name="index">Index 0-8 of the new value.</param>
            /// <param name="value">The value to check.</param>
            /// <param name="inclusive">Also check at the given index.</param>
            /// <returns>
            /// False if the value exists in the row of the index,
            /// excluding at the given index, unless inclusive is true.
            /// </returns>
            public bool IsValidValueInRow(int index, int value, bool inclusive)
            {
                for (int i=0; i<9; i++)
                {
                    bool sameRow = (i / 3 == index / 3);

                    if (sameRow && this.Values[i] == value)
                    {
                        if (i != index || inclusive)
                        {
                            return false;
                        }
                    }
                }

                return true;
            }

            public bool IsValidValueInColumn(int index, int value, bool inclusive)
            {
                for (int i = 0; i < 9; i++)
                {
                    bool sameCol = (i % 3 == index % 3);

                    if (sameCol && this.Values[i] == value)
                    {
                        if (i != index || inclusive)
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
        }

        public class SudokuBoard
        {
            public SudokuSquare[] Squares { get; set; }

            public SudokuBoard()
            {
                this.Squares = new SudokuSquare[9];

                for (int i = 0; i < 9; i++)
                {
                    this.Squares[i] = new SudokuSquare();
                }
            }

            public bool IsValid()
            {
                for (int i=0; i < 9*9; i++)
                {
                    if (!IsValid(i))
                    {
                        return false;
                    }
                }

                return true;
            }

            public bool IsValid(int index)
            {
                SudokuSquare square = this.Squares[index / 9];
                int inSquareIndex = index % 9;
                int value = square.Values[inSquareIndex];

                if (!square.IsValidValue(inSquareIndex, value))
                {
                    return false;
                }

                return this.IsValidValueInRowAndColumn(index, value);
            }

            public bool IsValidValueInRowAndColumn(int index, int value)
            {
                int squareIndex = index / 9;
                
                for (int i=0; i < 9; i++)
                {
                    if (i / 3 == squareIndex / 3)
                    {
                        if (!this.Squares[i].IsValidValueInRow(index % 9, value, squareIndex != i))
                        {
                            return false;
                        }
                    }
                }

                for (int i = 0; i < 9; i++)
                {
                    if (i % 3 == squareIndex % 3)
                    {
                        if (!this.Squares[i].IsValidValueInColumn(index % 9, value, squareIndex != i))
                        {
                            return false;
                        }
                    }
                }

                return true;
            }

            public override string ToString()
            {
                StringBuilder s = new StringBuilder();

                for (int i=0; i < 9*9; i++)
                {
                    int squareIndex = (i / 3) % 3 + 3 * (i / (9 * 3));
                    int inSquareIndex = i % 3 + ((3 * (i / 9)) % 9);               

                    int value = this.Squares[squareIndex].Values[inSquareIndex];
                    s.Append(value);

                    if ((inSquareIndex % 3) == 2)
                    {
                        s.Append("|");
                    }

                    if (i % 9 == 8)
                    {
                        s.Append("\n");
                    }

                    if ((i % (9 * 3)) == ((9 * 3) - 1))
                    {
                        for (int j = 0; j < 9 + 2; j++)
                        {
                            s.Append("-");
                        }
                        s.Append("\n");
                    }
                }

                return s.ToString();
            }
        }

        public static void Solve(SudokuBoard board)
        {
            SudokuSolver.Solve(board, 0);
        }

        /// <summary>
        /// Solves a sudoku board.
        /// </summary>
        /// <param name="board">The board to solve.</param>
        /// <param name="index">The zero-based index up to 99.</param>
        /// <returns>True if the board was solved.</returns>
        private static bool Solve(SudokuBoard board, int index)
        {
            if (index == 9*9)
            {
                return true;
            }

            SudokuSquare square = board.Squares[index / 9];
            int inSquareIndex = index % 9;

            for (int i=1; i<=9; i++)
            {
                square.Values[inSquareIndex] = i;

                if (board.IsValid(index))
                {
                    bool solved = SudokuSolver.Solve(board, index + 1);

                    if (solved)
                    {
                        return true;
                    }
                }
            }

            square.Values[inSquareIndex] = 0;
            return false;
        }
    }
}
