using Lb_9.Interfaces;
using Lb_9.Services;
using Microsoft.Extensions.DependencyInjection;

public class IoCContainer
{
    private readonly ServiceProvider _serviceProvider;

    public IoCContainer()
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        _serviceProvider = serviceCollection.BuildServiceProvider();
    }
    private void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<INotificationService, NotificationService>();
        services.AddSingleton<IUserService, UserService>();
        services.AddSingleton<ICategoryService, CategoryService>();
        services.AddSingleton<IBookService, BookService>();
        services.AddSingleton<ILibraryService, LibraryService>();
    }
    
    public ILibraryService LibraryService => _serviceProvider.GetRequiredService<ILibraryService>();
}