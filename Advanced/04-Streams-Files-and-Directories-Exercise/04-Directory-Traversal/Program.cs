//Write a program that traverses a given directory for all files with the given extension. Search through the first level of the
//directory only. Write information about each found file in a text file named report.txt and it should be saved on the Desktop.
//The files should be grouped by their extension. Extensions should be ordered by the count of their files descending, then by
//name alphabetically. Files under an extension should be ordered by their size. report.txt should be saved on the Desktop. Ensure
//the desktop path is always valid, regardless of the user.

namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            //string path = @"C:\WoW";
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            StringBuilder sb = new StringBuilder();
            string[] files = Directory.GetFiles(inputFolderPath);
            Dictionary<string, List<FileInfo>> allFiles = new Dictionary<string, List<FileInfo>>();

            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                if (!allFiles.ContainsKey(fileInfo.Extension))
                {
                    allFiles.Add(fileInfo.Extension, new List<FileInfo>());
                }
                allFiles[fileInfo.Extension].Add(fileInfo);
            }

            var orderedFiles = allFiles.OrderByDescending(x => x.Value.Count);
            foreach (var file in orderedFiles)
            {
                sb.AppendLine(file.Key);
                var orderedExtensionsFails = file.Value.OrderByDescending(x => x.Length);
                foreach (var item in orderedExtensionsFails)
                {
                    sb.AppendLine($"--{item.Name} - {(double)item.Length/1024:f3}kb");
                }
            }

            return sb.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;
            File.WriteAllText(path, textContent);
        }
    }
}
