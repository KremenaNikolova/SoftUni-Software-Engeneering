//Write a program that reads the contents of two input text files (e. g. input1.txt and input2.txt) and merges them line by line together into a third text file (e. g. output.txt). The merging is done as follows:
//•	Line 1 from input1.txt
//•	Line 1 from input2.txt
//•	Line 2 from input1.txt
//•	Line 2 from input2.txt
//•	…
//If some of the files have more lines than the other, append at the end of the output the lines, which cannot be matched with the other file.


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
            // TODO: write your code here…
        }
    }
}
