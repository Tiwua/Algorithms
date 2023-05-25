namespace _05._Paths_in_Labyrinth
{
	using System;
	using System.Collections.Generic;

	internal class Program
	{
		static void Main(string[] args)
		{
			int rows = int.Parse(Console.ReadLine());
			int cols = int.Parse(Console.ReadLine());

			char[,] matrix = new char[rows, cols];

			for (int r = 0; r < rows; r++)
			{
				var colElements = Console.ReadLine();

				for (int c = 0; c < colElements.Length; c++)
				{
					matrix[r, c] = colElements[c];
				}
			}

			FindPaths(matrix, 0, 0, new List<string>(), string.Empty);
		}

		private static void FindPaths(char[,] matrix, int row, int col, List<string> directions, string direction)
		{
			if (row < 0 || row >= matrix.GetLength(0) ||
				col < 0 || col >= matrix.GetLength(1))
			{
				return;
			}

			if (matrix[row, col] == '*' || matrix[row, col] == 'F')
			{
				return;
			}

			directions.Add(direction);

			if (matrix[row, col] == 'e')
			{
                Console.WriteLine(string.Join(string.Empty, directions));
				directions.RemoveAt(directions.Count - 1);
				return;
			}

			matrix[row, col] = 'F';

			FindPaths(matrix, row - 1, col, directions, "U"); //Up
			FindPaths(matrix, row + 1, col, directions, "D"); //Down
			FindPaths(matrix, row, col - 1, directions, "L"); //Left
			FindPaths(matrix, row, col + 1, directions, "R"); //Right

			matrix[row, col] = '-';
			directions.RemoveAt(directions.Count - 1);
		}
	}
}