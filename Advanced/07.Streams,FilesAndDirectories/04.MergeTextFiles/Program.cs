using System;
using System.IO;

namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            string line = String.Empty;
            var firstReader = new StreamReader(firstInputFilePath);
            var secondReader = new StreamReader(secondInputFilePath);
            var writer = new StreamWriter(outputFilePath);
            using (firstReader)
            {
                using (secondReader)
                {
                    using (writer)
                    {
                        while (line != null)
                        {
                            line = firstReader.ReadLine();
                            if (line != null)
                                writer.WriteLine(line);

                            line = secondReader.ReadLine();
                            if (line != null)
                                writer.WriteLine(line);
                        }
                    }
                }

            }
            
        }
    }
}

