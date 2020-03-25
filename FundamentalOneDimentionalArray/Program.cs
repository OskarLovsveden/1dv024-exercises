using System;

namespace FundamentalOneDimentionalArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbersArray = { 10, 23, 5, 1, 15 };
            logArray(numbersArray);
            System.Console.WriteLine();

            int[] processedArray = multiplyNumbersOverTen(numbersArray);
            logArray(processedArray);
        }

        static int[] multiplyNumbersOverTen(int[] numbersArray)
        {
            for (int i = 0; i < numbersArray.Length; i++)
            {
                if (numbersArray[i] > 10)
                {
                    numbersArray[i] *= 2;
                }
            }

            return numbersArray;
        }

        static void logArray(int[] arrayToLog)
        {
            foreach (var item in arrayToLog)
            {
                System.Console.Write($"{item} ");
            }
        }
    }
}
