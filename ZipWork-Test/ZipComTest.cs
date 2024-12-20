using System.IO;
using System.IO.Compression;
using Xunit;
using ZipWork.Services.Commands;
using ZipWork.Services.Strategies;

namespace ZipWork_Test;

public class ZipComTest
{
    [Fact]
    public void Execute_ShouldCallCompressMethod_WithCorrectParameters()
    {
        // Arrange
        var sourcePath = "testFolder";
        var destinationPath = "testCompress.zip";

        if (Directory.Exists(sourcePath)) Directory.Delete(sourcePath, true);
        if (File.Exists(destinationPath)) File.Delete(destinationPath);

        Directory.CreateDirectory(sourcePath);
        File.WriteAllText(Path.Combine(sourcePath, "file.txt"), "Test content");

        var realStrategy = new FolderCompressionStrategy();
        var compressionContext = new CompressionContext(realStrategy); 
        var zipCommand = new ZipCommand();
        zipCommand.SetProperties(sourcePath, destinationPath, compressionContext, CompressionLevel.Optimal, true); 

        try
        {
            // Act
            zipCommand.Execute();

            // Assert
            Assert.True(File.Exists(destinationPath));
        }
        finally
        {
            // Cleanup
            if (Directory.Exists(sourcePath)) Directory.Delete(sourcePath, true);
            if (File.Exists(destinationPath)) File.Delete(destinationPath);
        }
    }

    [Fact]
    public void ZipCommand_Execute_ShouldCreateZipFile()
    {
        // Arrange
        var sourcePath = "test/source.txt";
        var destinationPath = "test/output.zip";

        Directory.CreateDirectory("test");
        File.WriteAllText(sourcePath, "This is a test file");

        var compressionStrategy = new FileCompressionStrategy();
        var compressionContext = new CompressionContext(compressionStrategy); 
        var zipCommand = new ZipCommand();
        zipCommand.SetProperties(sourcePath, destinationPath, compressionContext, CompressionLevel.Optimal, false); 
        
        // Act
        zipCommand.Execute();

        // Assert
        Assert.True(File.Exists(destinationPath), "Zip file was not created.");

        // Cleanup
        if (File.Exists(destinationPath)) File.Delete(destinationPath);
        if (File.Exists(sourcePath)) File.Delete(sourcePath);
        if (Directory.Exists("test")) Directory.Delete("test");
    }
    
    [Fact]
    public void ZipCommand_Execute_ShouldThrowException_WhenSourceFileDoesNotExist()
    {
        // Arrange
        var sourcePath = "test/nonexistent.txt"; 
        var destinationPath = "test/output.zip";

        var compressionStrategy = new FileCompressionStrategy();
        var compressionContext = new CompressionContext(compressionStrategy); 
        var zipCommand = new ZipCommand();
        zipCommand.SetProperties(sourcePath, destinationPath, compressionContext, CompressionLevel.Optimal, false);

        // Act & Assert
        var exception = Assert.Throws<FileNotFoundException>(() => zipCommand.Execute());
        Assert.Equal($"The file '{sourcePath}' does not exist.", exception.Message);

        // Cleanup 
        if (File.Exists(destinationPath)) File.Delete(destinationPath);
    }
}
