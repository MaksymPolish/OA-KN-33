namespace Lb_11.Interface;

public interface INotificationHandler<TNotification>
{
    void Handle(TNotification notification);
}