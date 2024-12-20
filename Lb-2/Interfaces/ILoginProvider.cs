namespace Lb_2.Interfaces;


public interface ILoginProvider
{
    bool Validate(string login);
}