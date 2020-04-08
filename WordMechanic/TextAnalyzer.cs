using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordMechanic
{
    public static class TextAnalyzer
    {
        private static readonly Regex Rgx = new Regex(@"\W+");

        public static string[] ExtractWords(string line)
        {
            List<string> words = new List<string>();

            foreach (var word in Rgx.Split(line))
            {
                if (!string.IsNullOrWhiteSpace(word) && !Regex.IsMatch(word, @"\d"))
                {
                    words.Add(word);
                }
            }

            return words.ToArray();
        }

        public static string[] ExtractWords(string[] lines)
        {
            List<string[]> listOfWordArrays = new List<string[]>();

            foreach (var line in lines)
            {
                listOfWordArrays.Add(ExtractWords(line));
            }

            return listOfWordArrays.SelectMany(arrayOfWords => arrayOfWords).ToArray();
        }
        public static IDictionary<string, int> GetWordFrequency(string[] words)
        {
            IDictionary<string, int> wordFrequency = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (wordFrequency.ContainsKey(word))
                {
                    wordFrequency[word]++;
                }
                else
                {
                    wordFrequency[word] = 1;
                }
            }

            return wordFrequency;
        }
    }
}