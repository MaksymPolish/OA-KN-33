using ZipWork.Services.Interfaces;

namespace ZipWork.Services.Commands;

public class CommandInputService
{
    private readonly IConsoleWrapper _consoleWrapper;

    public CommandInputService(IConsoleWrapper consoleWrapper)
    {
        _consoleWrapper = consoleWrapper;
    }

    public string GetCompressionLevel()
    {
        _consoleWrapper.DisplayText("Choose compression level: A - High, B - Medium, C - Low");
        return Console.ReadLine().ToUpper();
    }

    public (string SourcePath, string TargetPath) GetPaths()
    {
        _consoleWrapper.DisplayText("Enter the source path: ");
        var sourcePath = Console.ReadLine();
        _consoleWrapper.DisplayText("Enter the destination path: ");
        var targetPath = Console.ReadLine();
        return (sourcePath, targetPath);
    }
}
