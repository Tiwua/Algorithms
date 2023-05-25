namespace _01.RecursiveArraySum
{
	using System;
	using System.Linq;

	internal class Program
	{
		static void Main()
		{
			try
			{
				int[] input = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

				Console.WriteLine(SumWithRecursion(input, 0));
			}
			catch (Exception)
			{

                Console.WriteLine("Input cannot be empty!");
			}
		}

		private static int SumWithRecursion(int[] input, int index)
		{
			if (index == input.Length - 1)
			{
				return input[index];
			}

			return input[index] + SumWithRecursion(input, index + 1);
		}
	}
}