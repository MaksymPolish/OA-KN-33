using Lb_11.Interface;

namespace Lb_11.Items;

public class ItemRequestHandler : IRequestHandler<ItemRequest, ItemResponse>
{
    private readonly IMediator _mediator;

    public ItemRequestHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public ItemResponse Handle(ItemRequest request)
    {
        try
        {
            Console.WriteLine($"Handling ItemRequest: {request.Message}");

            _mediator.Publish(new ItemNotification { NotificationMessage = "Item processed" });

            return new ItemResponse { ResponseMessage = "Item processed successfully" };
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error handling request: {e.Message}");
            throw new ApplicationException("An error occurred while processing the ItemRequest.", e);
        }
        
        
    }
}