namespace _02.RecursiveDrawing
{
	using System;

	internal class Program
	{
		static void Main()
		{
			var n = int.Parse(Console.ReadLine());

			RecursiveDrawing(n);
		}

		private static void RecursiveDrawing(int row)
		{
			if (row == 0)
			{
				return;
			}

            Console.WriteLine(new string('*', row));

			RecursiveDrawing(row - 1);

			Console.WriteLine(new string('#', row));
        }
	}
}