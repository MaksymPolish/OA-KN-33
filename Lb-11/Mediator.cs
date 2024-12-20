using Lb_11.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Lb_11;

public class Mediator : IMediator
{
    private readonly IServiceProvider _serviceProvider;

    public Mediator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public TResponse Send<TRequest, TResponse>(TRequest request)
    {
        try
        {
            var handler = _serviceProvider.GetService<IRequestHandler<TRequest, TResponse>>();
            if (handler == null)
                throw new InvalidOperationException($"Handler for {typeof(TRequest).Name} not registered");

            return handler.Handle(request);
        }
        catch (Exception e)
        {
            throw new ApplicationException($"An error occurred while processing the request: {e.Message}", e);
        }
        
    }

    public void Publish<TNotification>(TNotification notification)
    {
        try
        {
            var handlers = _serviceProvider.GetServices<INotificationHandler<TNotification>>();
            foreach (var handler in handlers)
            {
                handler.Handle(notification);
            }
        }
        catch (Exception e)
        {
            throw new ApplicationException($"An error occurred while processing the request: {e.Message}", e);
        }
    }
}

