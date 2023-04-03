using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Design_Task
{
    internal class Program
    {
        static void Main()
        {
            string? filePath;

            do
            {
                Console.WriteLine("Введите путь до файла: ");
                filePath = Console.ReadLine();
            }
            while (!File.Exists(filePath));

            if (filePath != null)
            {
                Dictionary<string, int> wordsWithCount = new();

                ReadFile(filePath, wordsWithCount);

                WriteResultInFile(wordsWithCount);
            }

            Console.WriteLine("Слова успешно посчитаны.");
        }

        static void ReadFile(string filePath, Dictionary<string, int> wordsWithCount)
        {
            foreach (var line in File.ReadLines(filePath))
            {
                string[] words = Regex.Replace(line, "(\\p{P})", string.Empty).Split(' ');

                foreach (var word in words)
                {
                    if (word != string.Empty)
                    {
                        if (wordsWithCount.ContainsKey(word.ToLower()))
                        {
                            wordsWithCount[word.ToLower()]++;
                        }
                        else
                        {
                            wordsWithCount[word.ToLower()] = 1;
                        }
                    }
                }
            }

        }

        static void WriteResultInFile(Dictionary<string, int> wordsWithCount)
        {
            var sortedDict = wordsWithCount.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            using var writer = new StreamWriter("WordsCountResult.txt");

            foreach (var word in sortedDict)
            {
                writer.WriteLine($"{word.Key}\t{word.Value}");
            }

        }
    }
}