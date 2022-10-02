using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace DirectoryTraversal
{
    using System;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            string[] files = Directory.GetFiles(inputFolderPath);
            var fileExtensions = new SortedDictionary<string, List<FileInfo>>();

            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);

                if(!fileExtensions.ContainsKey(fileInfo.Extension))
                    fileExtensions.Add(fileInfo.Extension,new List<FileInfo>());

                fileExtensions[fileInfo.Extension].Add(fileInfo);
            }

            var orderedFileExtensions = fileExtensions.OrderByDescending(fex => fex.Value.Count);

            var sb = new StringBuilder();

            foreach (var fileExtension in orderedFileExtensions)
            {
                sb.Append(fileExtension.Key);
                var orderedFiles = fileExtension.Value.OrderByDescending(f => f.Length);

                foreach (var file in orderedFiles)
                {
                    sb.Append($"--{file.Name} - {(double)file.Length / 1024:f3}kb");
                }
            }

            return sb.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;
            File.WriteAllText(filePath,textContent);
        }
    }
}