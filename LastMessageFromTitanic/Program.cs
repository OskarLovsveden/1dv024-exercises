using System;
using System.IO;

namespace LastMessageFromTitanic
{
    /// <summary>
    /// Represents the main place where the program starts the execution.
    /// </summary>
    static class Program
    {
        /// <summary>
        /// The starting point of the application.
        /// </summary>
        /// <param name="args">Array containing arguments passed to the application.</param>
        static void Main(string[] args)
        {
            try
            {   // Open the text file using a stream reader.
                using (var reader = new StreamReader(args[0]))
                {
                    var morseCode = new MorseCode();
                    // Read the stream to a string, and write the string to the console.
                    string line = reader.ReadToEnd();
                    Console.WriteLine(line);
                    morseCode.Play(line);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
