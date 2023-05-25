namespace _03.Generating0_1Vectors
{
	using System;

	internal class Program
	{
		static void Main(string[] args)
		{
			var n = int.Parse(Console.ReadLine());

			var array = new int[n];

			GenerateSolutions(array, 0);
		}

		private static void GenerateSolutions(int[] array, int index)
		{
			if (index >= array.Length)
			{
                Console.WriteLine(string.Join(string.Empty, array));
                return;
			}

			for (int i = 0; i < 2; i++)
			{
				array[index] = i;

				GenerateSolutions(array, index + 1);
			}
		}
	}
}