namespace _2.Nested_Loops_To_Recursion
{
    using System;

    internal class Program
    {
        private static int[] elements;
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            elements = new int[n];

            GenereteNumbers(0);
        }

        private static void GenereteNumbers(int index)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
                return;
            }

            for (int i = 1; i <= elements.Length; i++)
            {
                elements[index] = i;
                GenereteNumbers(index + 1);
            }
        }
    }
}