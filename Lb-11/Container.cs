using Lb_11.Interface;
using Lb_11.Items;
using Microsoft.Extensions.DependencyInjection;

namespace Lb_11;

public static class Container
{
    public static IServiceProvider ConfigureServices()
    {
        return new ServiceCollection()
            .AddTransient<IMediator, Mediator>()
            .AddTransient<ISender, Mediator>()
            .AddTransient<IPublisher, Mediator>()
            .AddTransient<IRequestHandler<ItemRequest, ItemResponse>, ItemRequestHandler>()
            .AddTransient<INotificationHandler<ItemNotification>, ItemNotificationHandler>()
            .BuildServiceProvider();
    }
}