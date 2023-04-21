//Write a program that creates a ZIP file (archive), holding a given input file, and extracts the ZIP-ed file from the archive
//into in separate output file.
//•	Use the copyMe.png file from your resources as input and zip it into a ZIP file of your choice, e. g. archive.zip.
//•	Extract the file from the archive into a new file of your choice, e. g. extracted.png.
//If your code works correctly, the input and output files should be the same.


namespace ZipAndExtract
{
    using System;
    using System.IO;
    using System.IO.Compression;

    public class ZipAndExtract
    {
        static void Main()
        {
            string inputFile = @"..\..\..\CopyMe.png";
            string zipArchiveFile = @"..\..\..\archive.zip";
            string extractedFile = @"..\..\..\extracted.png";

            ZipFileToArchive(inputFile, zipArchiveFile);

            var fileNameOnly = Path.GetFileName(inputFile);
            ExtractFileFromArchive(zipArchiveFile, fileNameOnly, extractedFile);
        }

        public static void ZipFileToArchive(string inputFilePath, string zipArchiveFilePath)
        {
            using (ZipArchive createZip = ZipFile.Open(inputFilePath, ZipArchiveMode.Create))
            {
                string fileName = Path.GetFileName(inputFilePath);
                createZip.CreateEntryFromFile(inputFilePath, fileName);
            }
        }

        public static void ExtractFileFromArchive(string zipArchiveFilePath, string fileName, string outputFilePath)
        {
            using (ZipArchive openZip = ZipFile.OpenRead(zipArchiveFilePath))
            {
                ZipArchiveEntry extraxtFile = openZip.GetEntry(fileName);
                extraxtFile.ExtractToFile(outputFilePath);
            }
        }
    }
}
