using System.IO.Compression;

namespace ZipWork.Services.Interfaces;

public interface ICompressionStrategy
{
    void Compress(string sourcePath, string destinationPath, CompressionLevel level);
    void Decompress(string sourcePath, string destinationPath);
}