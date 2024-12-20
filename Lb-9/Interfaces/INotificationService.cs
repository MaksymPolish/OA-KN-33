using Lb_9.Entitys;

namespace Lb_9.Interfaces;

public interface INotificationService
{
    void SendEmail(User user, string message);
}