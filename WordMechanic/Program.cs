using System.IO;
using System.Collections.Generic;

namespace WordMechanic
{
    class Program
    {
        static void Main(string[] args)
        {
            string readFile = args[0];
            string writeFile = args[1];

            string[] lines = File.ReadAllLines(readFile);
            string[] words = TextAnalyzer.ExtractWords(lines);
            IDictionary<string, int> wordFrequency = TextAnalyzer.GetWordFrequency(words);

            WriteToTxt.KVPWordsToTxt(wordFrequency, writeFile);
        }
    }
}
