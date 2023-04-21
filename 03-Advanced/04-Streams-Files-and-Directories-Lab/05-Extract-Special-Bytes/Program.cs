//You are given a binary file (e. g. example.png) and a text file (e. g. bytes.txt), holding a list of bytes in the range [0…255]. Write a program to extract occurrences of all given bytes from the input file to an output binary file (e. g. output.bin).

using System.Collections.Generic;
using System.IO;

namespace ExtractBytes
{
    public class ExtractBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
           using(FileStream bytes = new FileStream(bytesFilePath, FileMode.Open))
            {
                using (FileStream binary = new FileStream(binaryFilePath, FileMode.Open))
                {
                    byte[] bytesBuffer = new byte[bytes.Length];
                    bytes.Read(bytesBuffer, 0, (int)bytes.Length);

                    byte[] binaryBuffer = new byte[binary.Length];
                    binary.Read(binaryBuffer, 0, (int)binary.Length);

                    using (FileStream output = new FileStream(outputPath, FileMode.Create))
                    {
                        for (int i = 0; i < binaryBuffer.Length; i++)
                        {
                            for (int j = 0; j < bytesBuffer.Length; j++)
                            {
                                if (binaryBuffer[i] == bytesBuffer[j])
                                {
                                    output.Write(new byte[] { binaryBuffer[i] });
                                }
                            }
                        }
                    }
                    
                }
            }
        }
    }
}
