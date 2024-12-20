using Lb_3.Interfaces;

namespace Lb_3.Classes;

public class PaymentProcessor
{
    public void Process(IPaymentSystem paymentSystem, decimal amount)
    {
        paymentSystem.ProcessPayment(amount);
    }
}