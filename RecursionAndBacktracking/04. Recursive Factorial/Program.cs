namespace _04.RecursiveFactorial
{
	using System;

	internal class Program
	{
		static void Main(string[] args)
		{
			int number = int.Parse(Console.ReadLine());

            Console.WriteLine(CalcFactorialWithRecursion(number));
        }

		private static int CalcFactorialWithRecursion(int number)
		{
			if (number == 0)
			{
				return 1;
			}

			return number * CalcFactorialWithRecursion(number - 1);
		}
	}
}