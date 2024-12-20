using Lb_9.Entitys;
using Lb_9.Interfaces;

namespace Lb_9.Services;

public class NotificationService : INotificationService
{
    public void SendEmail(User user, string message)
    {
        Console.WriteLine($"Email sent to {user.Email}: {message}");
    }
}