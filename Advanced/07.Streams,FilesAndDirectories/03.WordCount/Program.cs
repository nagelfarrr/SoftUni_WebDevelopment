using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            string[] words;

            var reader = new StreamReader(wordsFilePath);
            using (reader)
            {
                words = reader.ReadLine().Split();
            }

            string[] input;
            char[] separators = { ' ', '.', ',', '-', '?', '!', };

            var textReader = new StreamReader(textFilePath);
            using (textReader)
            {
                input = textReader.ReadToEnd().Split(separators);
            }

            var wordOccurences = new Dictionary<string, int>();


            foreach (var wordToFind in words)
            {
                foreach (var inputWord in input)
                {
                    if (wordToFind.ToLower() == inputWord.ToLower())
                    {
                        if(!wordOccurences.ContainsKey(wordToFind))
                            wordOccurences.Add(wordToFind,0);

                        wordOccurences[wordToFind]++;
                    }
                }
            }

            var writer = new StreamWriter(outputFilePath);

            using (writer)
            {
                foreach (var word in wordOccurences.OrderByDescending(x=>x.Value))
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}

