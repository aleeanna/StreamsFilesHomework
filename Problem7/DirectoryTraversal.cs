using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem7
{
    class DirectoryTraversal
    {
        static void Main(string[] args)
        {
            string currentPath = Directory.GetCurrentDirectory();
            string[] filepaths = Directory.GetFiles(currentPath);

            List<FileInfo> files = filepaths.Select(path => new FileInfo(path)).ToList();

            var sorted =
                files.OrderBy(file => file.Length)
                    .GroupBy(file => file.Extension)
                    .OrderByDescending(group => group.Count())
                    .ThenBy(group => group.Key);

            string resultPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/result.txt";

            using (var writer = new StreamWriter(resultPath, false))
            {
                foreach (var extensionGroup in sorted)
                {
                    writer.WriteLine(extensionGroup.Key);

                    foreach (var fileInfo in extensionGroup)
                    {
                        writer.WriteLine("--{0} - {1:F3} kb", fileInfo.Name, fileInfo.Length/1024.0);
                    }
                }
            }
        }
    }
}
