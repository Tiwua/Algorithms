namespace _6._Word_Cruncher
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        private static Dictionary<int, List<string>> wordsByIndex;
        private static Dictionary<string, int> wordsCount;
        private static LinkedList<string> usedWords;
        private static string targetWord;

        static void Main()
        {
            var words = Console.ReadLine().Split(", ");

            targetWord = Console.ReadLine();
            wordsByIndex = new Dictionary<int, List<string>>();
            wordsCount = new Dictionary<string, int>();
            usedWords = new LinkedList<string>();

            foreach (var word in words)
            {
                var index = targetWord.IndexOf(word);

                if (index == -1)
                {
                    continue;
                }

                if (wordsCount.ContainsKey(word))
                {
                    wordsCount[word] += 1;
                    continue;
                }

                wordsCount[word] = 1;

                while (index != -1)
                {
                    if (!wordsByIndex.ContainsKey(index))
                    {
                        wordsByIndex[index] = new List<string>();
                    }

                    wordsByIndex[index].Add(word);

                    index = targetWord.IndexOf(word, index + 1);
                }
            }

            GenSolution(0);
        }

        private static void GenSolution(int index)
        {
            if (index == targetWord.Length)
            {
                Console.WriteLine(string.Join(" ", usedWords));
                return;
            }

            if (!wordsByIndex.ContainsKey(index))
            {
                return;
            }

            foreach (var word in wordsByIndex[index])
            {
                if (wordsCount[word] == 0)
                {
                    continue;
                }

                wordsCount[word] -= 1;
                usedWords.AddLast(word);

                GenSolution(index + word.Length);

                wordsCount[word] += 1;
                usedWords.RemoveLast();
            }
        }
    }
}