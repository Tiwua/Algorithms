namespace _5._School_Teams
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    internal class Program
    {
        static void Main()
        {
            var girls = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            var girlsCombination = new string[3];
            var girlsCombined = new List<string[]>();

            Combine(0 , 0, girls, girlsCombination, girlsCombined);

            var boys = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            var boysCombination = new string[2];
            var boysCombined = new List<string[]>();

            Combine(0, 0, boys, boysCombination, boysCombined);

            PrintOutput(girlsCombined, boysCombined);
      
        }

        private static void PrintOutput(List<string[]> girlsCombined, List<string[]> boysCombined)
        {
            foreach (var girlComb in girlsCombined)
            {
                foreach (var boyComb in boysCombined)
                {
                    Console.WriteLine($"{string.Join(", ", girlComb)}, {string.Join(", ", boyComb)}");
                }
            }
        }

        private static void Combine(int index, int start, string[] elements, string[] combination, List<string[]> combinations)
        {
            if (index >= combination.Length)
            {
                combinations.Add(combination.ToArray());
                return;
            }

            for (int i = start; i < elements.Length; i++)
            {
                combination[index] = elements[i];
                Combine(index + 1, i + 1, elements, combination, combinations);
            }
        }
    }
}