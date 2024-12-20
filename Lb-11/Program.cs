using Lb_11.Interface;
using Lb_11.Items;
using Microsoft.Extensions.DependencyInjection;

namespace Lb_11;

public class Program
{
    public static void Main(string[] args)
    {
        var serviceProvider = Container.ConfigureServices();

        var mediator = serviceProvider.GetService<IMediator>();

        var response = mediator.Send<ItemRequest, ItemResponse>(new ItemRequest { Message = "Process this item" });
        Console.WriteLine($"Response: {response.ResponseMessage}");

        mediator.Publish(new ItemNotification { NotificationMessage = "Item shipped" });
    }
}