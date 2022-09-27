//You are given a folder in the file system (e. g. TestFolder). Calculate the size of all files in the folder and its subfolders. The result should be written to another text (e. g. оutput.txt) file in kilobytes.

using System.IO;

namespace FolderSize
{
    public class FolderSize
    {
        static void Main()
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            DirectoryInfo folder = new DirectoryInfo(folderPath);
            FileInfo[] files = folder.GetFiles("*", SearchOption.AllDirectories);
            decimal sumBytes = 0;

            foreach (FileInfo file in files)
            {
                sumBytes += file.Length;
            }

            using(StreamWriter output = new StreamWriter(outputFilePath))
            {
                output.Write(sumBytes/1024);
            }
        }
    }
}

