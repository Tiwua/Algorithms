namespace _07._Recursive_Fibonacci
{
	using System;
	using System.Collections.Generic;

	internal class Program
	{
		static void Main()
		{
			int number = int.Parse(Console.ReadLine());

			var fibonacci = new List<int>();

			fibonacci.Add(0);
			fibonacci.Add(1);

			while (fibonacci.Count < number + 2)
			{
				var newFibonacci = fibonacci[^1] + fibonacci[^2];
				fibonacci.Add(newFibonacci);
			}

            Console.WriteLine(CalcFib(number));
        }

		private static long CalcFib(int number)
		{
			if (number <=1)
			{
				return 1;
			}

			return CalcFib(number - 1) + CalcFib(number - 2);
		}
	}
}