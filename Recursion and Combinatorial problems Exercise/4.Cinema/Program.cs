namespace _4._Cinema
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    internal class Program
    {
        private static List<string> movingPeople;
        private static string[] people;
        private static bool[] locked;

        static void Main()
        {
            movingPeople = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            people = new string[movingPeople.Count];
            locked = new bool[movingPeople.Count];

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "generate")
                {
                    break;
                }

                var args = input.Split(" - ");
                string name = args[0];
                int position = int.Parse(args[1]) - 1;

                people[position] = name;
                locked[position] = true;

                movingPeople.Remove(name);

            }
                Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= movingPeople.Count)
            {
                PrintOutput();
                return;
            }

            Permute(index + 1);

            for (int i = index + 1; i < movingPeople.Count; i++)
            {
                Swap(index, i);
                Permute(index + 1);
                Swap(index, i);
            }
        }

        private static void PrintOutput()
        {
            var personIndex = 0;
            for (int i = 0; i < people.Length; i++)
            {
                if (!locked[i])
                {
                    people[i] = movingPeople[personIndex++];
                }

            }
                Console.WriteLine(string.Join(" ", people));       
        }

        private static void Swap(int first, int second)
        {
            var temp = movingPeople[first]; 
            movingPeople[first] = movingPeople[second]; 
            movingPeople[second] = temp;
        }
    }
}