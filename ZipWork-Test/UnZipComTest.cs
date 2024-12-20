using System.IO.Compression;
using Xunit;
using ZipWork.Services.Commands;
using ZipWork.Services.Strategies;

namespace ZipWork_Test
{
    public class UnZipComTest
    {
        [Fact]
        public void Execute_ShouldCallDecompressMethod_WithCorrectParameters()
        {
            // Arrange
            var sourcePath = "testDecompress.zip";
            var destinationPath = "outputFolder";

            if (File.Exists(sourcePath)) File.Delete(sourcePath);
            if (Directory.Exists(destinationPath)) Directory.Delete(destinationPath, true);

            Directory.CreateDirectory("testFolder");
            File.WriteAllText(Path.Combine("testFolder", "file.txt"), "Test content");
            ZipFile.CreateFromDirectory("testFolder", sourcePath);
            Directory.Delete("testFolder", true);

            var realStrategy = new FolderCompressionStrategy();
            var compressionContext = new CompressionContext(realStrategy);
            var unzipCommand = new UnZipCommand();
            unzipCommand.SetProperties(sourcePath, destinationPath);

            try
            {
                // Act
                unzipCommand.Execute();

                // Assert
                Assert.True(Directory.Exists(destinationPath));
                Assert.NotEmpty(Directory.GetFiles(destinationPath));
            }
            finally
            {
                if (File.Exists(sourcePath)) File.Delete(sourcePath);
                if (Directory.Exists(destinationPath)) Directory.Delete(destinationPath, true);
            }
        }

        [Fact]
        public void UnZipCommand_Execute_ShouldExtractFiles()
        {
            // Arrange
            var zipFilePath = "test/archive.zip";
            var extractPath = "test/extracted";

            // Prepare archive for the test
            Directory.CreateDirectory("test");
            using (var zip = ZipFile.Open(zipFilePath, ZipArchiveMode.Create))
            {
                var entry = zip.CreateEntry("file.txt");
                using var entryStream = entry.Open();
                using var writer = new StreamWriter(entryStream);
                writer.Write("Test content");
            }

            var unZipCommand = new UnZipCommand();
            unZipCommand.SetProperties(zipFilePath, extractPath);

            // Act
            unZipCommand.Execute();

            // Assert
            Assert.True(File.Exists(Path.Combine(extractPath, "file.txt")), "File was not extracted.");

            // Cleanup
            if (File.Exists(zipFilePath)) File.Delete(zipFilePath);
            if (Directory.Exists(extractPath)) Directory.Delete(extractPath, true);
            if (Directory.Exists("test")) Directory.Delete("test");
        }
        
        [Fact]
        public void UnZipCommand_Execute_ShouldThrowException_WhenZipFileDoesNotExist()
        {
            // Arrange
            var zipFilePath = "test/nonexistent.zip"; 
            var extractPath = "test/extracted";

            var unZipCommand = new UnZipCommand();
            unZipCommand.SetProperties(zipFilePath, extractPath);

            // Act & Assert
            var exception = Assert.Throws<FileNotFoundException>(() => unZipCommand.Execute());
            Assert.Equal($"The zip file '{zipFilePath}' does not exist.", exception.Message);

            // Cleanup 
            if (Directory.Exists(extractPath)) Directory.Delete(extractPath, true);
        }
    }
}