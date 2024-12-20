using Lb_3.Interfaces;


namespace Lb_3.Classes;

public class PayoneerAccount : IPaymentSystem
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Обробка платежу {amount} через PayoneerAccount.");
    }
}