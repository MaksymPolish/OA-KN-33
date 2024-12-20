using Lb_11.Interface;

namespace Lb_11.Items;

public class ItemNotificationHandler : INotificationHandler<ItemNotification>
{
    public void Handle(ItemNotification notification)
    {
        Console.WriteLine($"Handling Notification: {notification.NotificationMessage}");
    }
}