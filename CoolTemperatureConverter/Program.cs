using System;

namespace CoolTemperatureConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            double fahrenheit = GetFahrenheit();
            double celsius = FahrenheitToCelsius(fahrenheit);

            Console.WriteLine($"Temperaturen {fahrenheit} ºF motsvarar {celsius:f1} ºC");
        }

        private static double GetFahrenheit()
        {
            while (true)
            {
                try
                {
                    Console.Write("Ange temperaturen i grader Fahrenheit: ");
                    string input = Console.ReadLine();

                    if (!double.TryParse(input, out _))
                    {
                        throw new ApplicationException();
                    }
                    else
                    {
                        double fahrenheit = double.Parse(input);
                        return fahrenheit;
                    }

                }
                catch (Exception)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nFEL! Ange ett gradantal som ett nummer.\n");
                    Console.ResetColor();
                }
            }
        }

        private static double FahrenheitToCelsius(double fahrenheit)
        {
            double celsius = (fahrenheit - 32) * 5 / 9;
            return celsius;
        }
    }
}