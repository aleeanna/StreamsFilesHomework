using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem3
{
    class WordCount
    {
        static void Main(string[] args)
        {
            ////string pathWords = Directory.GetCurrentDirectory() + @"\words.txt";
           // string pathText = Directory.GetCurrentDirectory() + @"\text.txt";

            using (var readWords = new StreamReader("../../words.txt"))
            {
                using (var readText = new StreamReader("../../text.txt"))
                {
                    using (var writeResult = new StreamWriter("../../result.txt", true))
                    {
                        var text = readText.ReadToEnd().ToLower(); 
                        var result = new SortedDictionary<int, string> ();
                        string word;

                        while ((word = readWords.ReadLine()) != null)
                        {
                            var pattern = string.Format(@"\b{0}\b", word.ToLower());
                            var match = Regex.Matches(text, pattern);
                            result.Add(match.Count, word);
                        }
                        foreach (var match in result.Reverse())
                        {
                            writeResult.WriteLine("{0} - {1}", match.Value, match.Key);
                        }

                    }
                }
            }
        }
    }
}
