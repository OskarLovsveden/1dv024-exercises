using System;

namespace RepeatableQuotes
{

    class QuoteViewer
    {
        private int _count;

        public int Count { get => _count; set => _count = value; }

        public string Quote { get; set; }

        public QuoteViewer() { }

        public QuoteViewer(string quote, int count)
        {
            Quote = quote;
            Count = count;
        }

        public void View()
        {
            Console.WriteLine("-----");
            for (int i = 0; i < _count; i++)
            {
                Console.WriteLine(Quote);
            }
            Console.WriteLine("-----");
        }
    }
}