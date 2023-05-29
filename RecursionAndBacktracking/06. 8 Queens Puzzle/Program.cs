namespace _06._8_Queens_Puzzle
{
	using System;
	using System.Collections.Generic;
	internal class Program
	{
		private static HashSet<int> attackedRows = new HashSet<int>();
		private static HashSet<int> attackedCols = new HashSet<int>();
		private static HashSet<int> attackedLeftDiagonals = new HashSet<int>();
		private static HashSet<int> attackedRightDiagonals = new HashSet<int>();

		static void Main()
		{
			bool[,] matrix = new bool[8, 8];

			PlaceQuees(matrix, 0);
		}

		private static void PlaceQuees(bool[,] matrix, int row)
		{
			if (row >= matrix.GetLength(0))
			{
				PrintBoard(matrix);
				return;
			}

			for (int col = 0; col < matrix.GetLength(1); col++)
			{
				if (CanPlaceQueen(row, col))
				{
					attackedRows.Add(row);
					attackedCols.Add(col);
					attackedLeftDiagonals.Add(row - col);
					attackedRightDiagonals.Add(row + col);
					matrix[row, col] = true;

					PlaceQuees(matrix, row + 1);

					attackedRows.Remove(row);
					attackedCols.Remove(col);
					attackedLeftDiagonals.Remove(row - col);
					attackedRightDiagonals.Remove(row + col);
					matrix[row, col] = false;
				}
			}
		}

		private static void PrintBoard(bool[,] matrix)
		{
			for (int row = 0; row < matrix.GetLength(0); row++)
			{
				for (int col = 0; col < matrix.GetLength(1); col++)
				{
					if (matrix[row, col])
					{
						Console.Write("* ");
					}
					else
					{
						Console.Write("- ");
					}
				}

                Console.WriteLine();
            }

            Console.WriteLine();
        }

		private static bool CanPlaceQueen(int row, int col)
		{
			return !attackedRows.Contains(row) &&
				   !attackedCols.Contains(col) &&
				   !attackedLeftDiagonals.Contains(row - col) &&
				   !attackedRightDiagonals.Contains(row + col);
		}
	}
}