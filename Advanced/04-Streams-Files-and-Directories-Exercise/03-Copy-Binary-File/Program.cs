//Write a program that copies the contents of a binary file (e. g. copyMe.png) to another binary file (e. g. copyMe-copy.png) using FileStream.You are not allowed to use the File class or similar helper classes.

namespace CopyBinaryFile
{
    using System;
    using System.IO;

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
            using (FileStream original = new FileStream(inputFilePath, FileMode.Open))
            {
                using (FileStream copy = new FileStream(outputFilePath, FileMode.Create))
                {
                    byte[] buffer = new byte[original.Length];
                    original.Read(buffer);
                    copy.Write(buffer);
                }
            }
        }
    }
}
