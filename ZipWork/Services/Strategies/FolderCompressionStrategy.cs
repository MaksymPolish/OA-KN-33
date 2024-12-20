using System.IO.Compression;
using ZipWork.Services.Interfaces;

namespace ZipWork.Services.Strategies;

public class FolderCompressionStrategy : ICompressionStrategy
{
    public void Compress(string sourcePath, string destinationPath, CompressionLevel level)
    {
        ZipFile.CreateFromDirectory(sourcePath, destinationPath, level, true);
        Console.WriteLine("Folder compressed successfully.");
    }

    public void Decompress(string sourcePath, string destinationPath)
    {
        ZipFile.ExtractToDirectory(sourcePath, destinationPath);
        Console.WriteLine("Folder decompressed successfully.");
    }
}