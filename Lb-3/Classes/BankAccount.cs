namespace Lb_3.Classes;
using Lb_3.Interfaces;

public class BankAccount : IPaymentSystem
{
    public virtual void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Обробка платежу {amount} через BankAccount.");
    }
}