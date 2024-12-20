using Lb_3.Interfaces;

namespace Lb_3.Classes;

public class WiseAccount : IPaymentSystem
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Обробка платежу {amount} через WiseAccount.");
    }
}