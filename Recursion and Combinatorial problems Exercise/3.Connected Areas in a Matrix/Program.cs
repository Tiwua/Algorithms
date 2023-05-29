namespace _3.Connected_Areas_in_a_Matrix
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Area
    {
        public int Row { get; set; }

        public int Col { get; set; }

        public int Size { get; set; }
    }

    internal class Program
    {
        private static char VisitedSymbol = 'V';
        private static char[,] matrix;
        private static int size;
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());    
            int cols = int.Parse(Console.ReadLine());

            matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var colElements = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }

            var areas = new List<Area>();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    size = 0;

                    ExploreMatrix(row, col);

                    if (size != 0)
                    {
                        areas.Add(new Area
                        {
                            Row = row,
                            Col = col,
                            Size = size
                        });
                    }
                }
            }

            var sortedAreas = areas
                .OrderByDescending(s => s.Size)
                .ThenBy(r => r.Row)
                .ThenBy(c => c.Col)
                .ToArray();

            Console.WriteLine($"Total areas found: {areas.Count}");

            for (int i = 0; i < sortedAreas.Length; i++)
            {
                var area = sortedAreas[i];
                Console.WriteLine($"Area #{i + 1} at ({area.Row}, {area.Col}), size: {area.Size}");
            }
        }

        private static void ExploreMatrix(int row, int col)
        {
            if (IsOutside(row, col) || IsWall(row, col) || IsVisited(row, col))
            {
                return;
            }

            size += 1;
            matrix[row, col] = VisitedSymbol;

            ExploreMatrix(row - 1, col); //Up
            ExploreMatrix(row + 1, col); //Down
            ExploreMatrix(row, col - 1); //Left
            ExploreMatrix(row, col + 1); //Right
        }

        private static bool IsVisited(int row, int col)
        {
            return matrix[row, col] == VisitedSymbol;
        }

        private static bool IsWall(int row, int col)
        {
            return matrix[row, col] == '*';
        }

        private static bool IsOutside(int row, int col)
        {
            return row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1);
        }
    }
}