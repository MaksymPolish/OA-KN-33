namespace Lb_11.Interface;

public interface ISender
{
    TResponse Send<TRequest, TResponse>(TRequest request);
}