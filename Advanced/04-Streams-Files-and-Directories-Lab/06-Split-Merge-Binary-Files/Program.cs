//You are given an input binary file (e. g. example.png). Write a program to split it into two equal-sized files (e. g. part-1.bin and part-2.bin). When the input file size is an odd number, the first part should be 1 byte bigger than the second.
//After splitting the input file, join the obtained files into a new file(e.g.example - joined.png).The obtained result file should be the same as the initial input file.


using System.IO;

namespace SplitMergeBinaryFile
{
    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        //Write a program to split it into two equal-sized files
        //When the input file size is an odd number, the first part should be 1 byte bigger than the second.
        //After splitting the input file, join the obtained files into a new file (e. g. example-joined.png). 
        //The obtained result file should be the same as the initial input file.

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            using (FileStream original = new FileStream(sourceFilePath, FileMode.Open))
            {
                using(FileStream partOne = new FileStream(partOneFilePath, FileMode.Create))
                {
                    int odd = original.Length % 2 == 1 ? 1 : 0;
                    byte[] buffer = new byte[original.Length/2+odd];
                    original.Read(buffer);
                    partOne.Write(buffer);
                }
                using(FileStream partTwo = new FileStream(partTwoFilePath, FileMode.Create))
                {
                    byte[] buffer = new byte[original.Length / 2];
                    original.Read(buffer);
                    partTwo.Write(buffer);
                }
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using (FileStream merged = new FileStream(joinedFilePath, FileMode.Create))
            {
                using(FileStream partOne = new FileStream(partOneFilePath, FileMode.Open))
                {
                    byte[] buffer =new byte [partOne.Length];
                    partOne.Read(buffer);
                    merged.Write(buffer);
                }
                using(FileStream partTwo = new FileStream(partTwoFilePath, FileMode.Open))
                {
                    byte[] buffer = new byte[partTwo.Length];
                    partTwo.Read(buffer);
                    merged.Write(buffer);
                }
            }
        }
    }
}
