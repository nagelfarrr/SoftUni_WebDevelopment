using System.IO;

namespace CopyBinaryFile
{
    using System;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            var fileReader = new FileStream(inputFilePath, FileMode.Open);
            var fileWriter = new FileStream(outputFilePath, FileMode.Create);

            using (fileReader)
            {
                using (fileWriter)
                {
                    while (true)
                    {
                        byte[] buffer = new byte[512];
                        int size = fileReader.Read(buffer, 0, buffer.Length);

                        if (size == 0)
                        {
                            break;
                        }
                        fileWriter.Write(buffer, 0, size);
                    }
                }
            }
        }
    }
}