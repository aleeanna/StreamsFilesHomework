using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    class LineNumbers
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("../../WithoutLineNums.txt"))
            {
                using (var writer = new StreamWriter("../../WithLineNums.txt"))
                {
                    int lineCount = 1;
                    while (reader.ReadLine() != null)
                    {
                        string line = reader.ReadLine();
                        
                        writer.WriteLine(lineCount + " " + line);
                        lineCount++;
                    }
                }
            }

        }
    }
}
