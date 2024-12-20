using System.IO.Compression;
using ZipWork.Services.Interfaces;

namespace ZipWork.Services.Strategies
{
    public class FileCompressionStrategy : ICompressionStrategy
    {
        public void Compress(string sourcePath, string destinationPath, CompressionLevel level)
        {
            using (FileStream sourceStream = new FileStream(sourcePath, FileMode.Open))
            using (FileStream destinationStream = File.Create(destinationPath))
            using (GZipStream compressionStream = new GZipStream(destinationStream, level))
            {
                sourceStream.CopyTo(compressionStream);
            }
            Console.WriteLine("File compressed successfully.");
        }

        public void Decompress(string sourcePath, string destinationPath)
        {
            using (FileStream sourceStream = new FileStream(sourcePath, FileMode.Open))
            using (FileStream destinationStream = File.Create(destinationPath))
            using (GZipStream decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
            {
                decompressionStream.CopyTo(destinationStream);
            }
            Console.WriteLine("File decompressed successfully.");
        }
    }
}
