namespace RepeatableQuotes
{
    /// <summary>
    /// Represents the main place where the program starts the execution.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The starting point of the application.
        /// </summary>
        static void Main()
        {
            // Create a new QuoteViewer object using the default
            // constructor, assign the object values using properties and
            // call a method.
            QuoteViewer qw = new QuoteViewer();
            qw.Quote = "I have a dream.";
            qw.Count = 7;
            qw.View();

            // Create and initiate another QuoteViewer object using
            // constructor having two parameters and calls a method.
            QuoteViewer anotherQw = new QuoteViewer("Make love, not war.", 3);
            anotherQw.View();

            // Change the object data using a property and call a method.
            anotherQw.Quote = "Et tu, Brute";
            anotherQw.View();
        }
    }
}
