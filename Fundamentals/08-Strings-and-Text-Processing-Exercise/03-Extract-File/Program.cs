using System;

namespace _03_Extract_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split("\\");

            string[] fullFileName = input[input.Length-1].Split(".");
            string fileName = fullFileName[0];
            string fileExtension = fullFileName[1];
            

            Console.WriteLine("File name: " + fileName);
            Console.WriteLine("File extension: " + fileExtension);
        }
    }
}
