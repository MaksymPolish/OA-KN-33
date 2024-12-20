using System.IO.Compression;
using Microsoft.Extensions.DependencyInjection;
using ZipWork.Services.Commands;
using ZipWork.Services.Interfaces;
using ZipWork.Services.Strategies;

namespace ZipWork.Services.CommandManager;

public class Invoker
{
    private const string ZipFileCommandChar = "A";
    private const string ZipFolderCommandChar = "B";
    private const string ExitCommandChar = "E";
    private const string UnzipCommandChar = "U";
    
    private const string HighCompressionCommandChar = "A";
    private const string MediumCompressionCommandChar = "B";
    private const string LowCompressionCommandChar = "C";

    private readonly Dictionary<string, CompressionLevel> _compressionLevels;
    private readonly Dictionary<string, (Func<ICommand> CommandFactory, string Name)> _commands;
    private IServiceProvider _serviceProvider;
    private IConsoleWrapper _consoleWrapper;
    private readonly CommandInputService _inputService;

    public Invoker(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _consoleWrapper = _serviceProvider.GetService<IConsoleWrapper>();
        _inputService = new CommandInputService(_consoleWrapper);

        _compressionLevels = new Dictionary<string, CompressionLevel>
        {
            { HighCompressionCommandChar, CompressionLevel.Optimal },
            { MediumCompressionCommandChar, CompressionLevel.Fastest },
            { LowCompressionCommandChar, CompressionLevel.NoCompression }
        };

        _commands = new Dictionary<string, (Func<ICommand>, string)>
        {
            { ZipFileCommandChar, (() => CreateZipCommand(false), "Zip a file") },
            { ZipFolderCommandChar, (() => CreateZipCommand(true), "Zip a folder") },
            { UnzipCommandChar, (() => UnzipArchiveCommand(), "Unzip an archive") },
            { ExitCommandChar, (() => ExitMenuCommand(), "Exit") }
        };
    }

    public void Run()
    {
        while (true)
        {
            ShowCommands();
            string choice = Console.ReadLine().ToUpper();

            try
            {
                ExecuteCommand(choice);
            }
            catch (Exception ex)
            {
                _consoleWrapper.DisplayText($"Error occurred: {ex.Message}");
            }
        }
    }

    public void ShowCommands()
    {
        _consoleWrapper.DisplayText("Commands: ");
        foreach (var cmd in _commands)
        {
            _consoleWrapper.ShowCommand(cmd.Key, cmd.Value.Name);
        }
    }

    private ICommand ExitMenuCommand()
    {
        Thread.Sleep(500);
        var exitCommand = new ExitCommand();
        return exitCommand;
    }

    private ICommand UnzipArchiveCommand()
    {
        _consoleWrapper.DisplayText("Enter the full path to the zip file: ");
        var sourcePath = Console.ReadLine();
        _consoleWrapper.DisplayText("Enter the full path to the destination folder: ");
        var targetPath = Console.ReadLine();
        var unZipCommand = _serviceProvider.GetRequiredService<UnZipCommand>();
        unZipCommand.SetProperties(sourcePath, targetPath);

        return unZipCommand;
    }

    private ICommand CreateZipCommand(bool isFolder)
    {
        string compressionChoice = _inputService.GetCompressionLevel();

        if (!_compressionLevels.TryGetValue(compressionChoice, out var level))
        {
            throw new ArgumentException("Invalid compression level");
        }

        ICompressionStrategy compressionStrategy = isFolder
            ? _serviceProvider.GetRequiredService<FolderCompressionStrategy>()
            : _serviceProvider.GetRequiredService<FileCompressionStrategy>();

        var zipCommand = _serviceProvider.GetRequiredService<ZipCommand>();
        var (sourcePath, targetPath) = _inputService.GetPaths();

        zipCommand.SetProperties(sourcePath, targetPath, new CompressionContext(compressionStrategy), level, isFolder);

        return zipCommand;
    }
    public bool ExecuteCommand(string choice)
    {
        if (_commands.TryGetValue(choice, out var commandInfo))
        {
            var command = commandInfo.CommandFactory();
            command.Execute();
            return true;
        }

        _consoleWrapper.DisplayText("Invalid Input");
        return true;
    }
}
