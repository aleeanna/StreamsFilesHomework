using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem5
{
    class SliceFile
    {
        private const string sourceFile = "../../SomeText.txt";
        private const string destinationDirectory = "../../assembled.txt";

        static void Main(string[] args)
        {
            int parts = int.Parse(Console.ReadLine());

            SliceParts(parts);

            for (int i = 0; i < parts; i++)
            {
                AssembleFile(i);
            }

        }

        static void SliceParts(int parts)
        {
            using (var sourceStream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read))
            {
                long sliceSize = (sourceStream.Length) / parts;
                long leftovers = sourceStream.Length - (sliceSize * parts);

                for (int i = 0; i < parts; i++)
                {
                    using (var destination = new FileStream(string.Format("../../Part {0}.txt", i), FileMode.Create))
                    {
                        sliceSize = (i < parts - 1) ? sliceSize : sliceSize + leftovers;
                        var buffer = new byte[sliceSize];
                        sourceStream.Read(buffer, 0, buffer.Length);
                        destination.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }

        static void AssembleFile(int i)
        {
            using (var sourceFiles = new FileStream(string.Format("../../Part {0}.txt", i), FileMode.Open))
            {
                using (var destination = new FileStream(destinationDirectory, i == 0 ? FileMode.Create : FileMode.Append))
                {
                    var buffer = new byte[sourceFiles.Length];
                    sourceFiles.Read(buffer, 0, buffer.Length);
                    destination.Write(buffer,0, buffer.Length);
                }
            }
        }
    }
}
