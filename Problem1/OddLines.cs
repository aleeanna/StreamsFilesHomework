using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    internal class OddLines
    {
        private static void Main(string[] args)
        {
            using (var reader = new StreamReader("SomeText.txt"))
            {
                int lineNumber = 0;
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    lineNumber++;

                    if (lineNumber%2 == 1)
                    {
                        Console.WriteLine("Line {0}: {1}", lineNumber, line);
                    }
                }

            }   
        }
    }
}

