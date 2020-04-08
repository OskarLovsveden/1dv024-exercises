using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace WordMechanic
{
    public static class WriteToTxt
    {
        public static void KVPWordsToTxt(IDictionary<string, int> kvpWords, string destination)
        {
            var alphabeticallyOrdered = kvpWords
                    .OrderBy(kvp => kvp.Key)
                    .Select(x => x.ToString());

            File.WriteAllLines(destination, alphabeticallyOrdered);
        }
    }
}