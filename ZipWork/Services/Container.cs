using Microsoft.Extensions.DependencyInjection;
using ZipWork.Services.Commands;
using ZipWork.Services.ConsoleWrap;
using ZipWork.Services.Interfaces;
using ZipWork.Services.Strategies;

namespace ZipWork.Services;

public static class Container
{
    public static IServiceCollection RegisterServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddSingleton<CompressionContext>()
            .AddSingleton<FileCompressionStrategy>()
            .AddSingleton<FolderCompressionStrategy>()
            .AddSingleton<ZipCommand>() 
            .AddSingleton<UnZipCommand>()
            .AddTransient<ExitCommand>()
            .AddSingleton<IConsoleWrapper, ConsoleWrapper>();
    }

}