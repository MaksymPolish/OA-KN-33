namespace Lb_11.Interface;

public interface IRequestHandler<TRequest, TResponse>
{
    TResponse Handle(TRequest request);
}