using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem4
{
    class CopyBinaryFile
    {
        private const string picPath = "../../979691_10200705060242404_446927369_n.jpg";

        static void Main(string[] args)
        {
            FileStream inputStream = new FileStream(picPath, FileMode.Open);
            FileStream copyPic = new FileStream("../../copy.jpg", FileMode.Create);

            using (inputStream)
            {
                using (copyPic)
                {
                    byte[] buffer = new byte[4096];

                    while (true)
                    {
                        int readBytes = inputStream.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0)
                        {
                            break;
                        }

                        copyPic.Write(buffer,0,buffer.Length);
                    }
                }
            }
        }
    }
}
