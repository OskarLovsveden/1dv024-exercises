using System;

namespace ProductOfIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberLimit = 20;
            multiplyIntegers(numberLimit);
        }

        static void multiplyIntegers(int numberLimit)
        {
            long result = 1;

            for (int i = 0; i < numberLimit; i++)
            {
                result *= (i + 1);
            }

            // Display the result. 2432902008176640000.
            Console.WriteLine($"Produkten av alla heltal mellan 1 och 20 är {result}.");
        }
    }
}
