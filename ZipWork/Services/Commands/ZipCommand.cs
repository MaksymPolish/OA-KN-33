using System.IO.Compression;
using ZipWork.Services.Interfaces;
using ZipWork.Services.Strategies;

namespace ZipWork.Services.Commands;

public class ZipCommand : ICommand
{
    private string _sourcePath;
    private string _targetPath;
    private CompressionContext _context;
    private CompressionLevel _compressionLevel;
    private bool _isFolder;

    public void Execute()
    {
        if (_context == null)
            throw new InvalidOperationException("Compression context not set.");
        if (string.IsNullOrWhiteSpace(_sourcePath))
            throw new InvalidOperationException("Source path not set.");
        if (string.IsNullOrWhiteSpace(_targetPath))
            throw new InvalidOperationException("Destination path not set.");

        if (_isFolder)
        {
            if (!Directory.Exists(_sourcePath))
                throw new DirectoryNotFoundException($"The folder '{_sourcePath}' does not exist.");
        }
        else
        {
            if (!File.Exists(_sourcePath))
                throw new FileNotFoundException($"The file '{_sourcePath}' does not exist.");
        }

        _context.Compress(_sourcePath, _targetPath, _compressionLevel);
    }

    public void SetProperties(string sourcePath, string targetPath, CompressionContext context, CompressionLevel level, bool isFolder)
    {
        _sourcePath = sourcePath;
        _targetPath = targetPath;
        _context = context;
        _compressionLevel = level;
        _isFolder = isFolder;
    }
}