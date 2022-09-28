//Write a method, which copies a directory with files (without its subdirectories) to another directory. The input folder and the
//output folder should be given as parameters from the console. If the output folder already exists, first delete it (together
//with all its content).

namespace CopyDirectory
{
    using System;
    using System.IO;

    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath = @$"{Console.ReadLine()}";
            string outputPath = @$"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            if (Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath, true);
            }
            Directory.CreateDirectory(outputPath);
            string[] files = Directory.GetFiles(inputPath);

            foreach (var file in files)
            {
                string fileName = Path.GetFileName(file);
                string destination = Path.Combine(outputPath, fileName);

                File.Copy(inputPath, destination);
            }
        }
    }
}
