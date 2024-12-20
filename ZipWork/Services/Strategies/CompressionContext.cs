using System.IO.Compression;
using ZipWork.Services.Interfaces;

namespace ZipWork.Services.Strategies
{
    public class CompressionContext
    {
        private readonly ICompressionStrategy _compressionStrategy;

        public CompressionContext(ICompressionStrategy compressionStrategy)
        {
            _compressionStrategy = compressionStrategy;
        }

        public void Compress(string sourcePath, string destinationPath, CompressionLevel level)
        {
            _compressionStrategy.Compress(sourcePath, destinationPath, level);
        }

        public void Decompress(string sourcePath, string destinationPath)
        {
            _compressionStrategy.Decompress(sourcePath, destinationPath);
        }
    }
}
