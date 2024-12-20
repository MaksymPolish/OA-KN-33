namespace Lb_11.Interface;

public interface IPublisher
{
    void Publish<TNotification>(TNotification notification);
}
