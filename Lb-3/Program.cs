using System;
using Lb_3.Interfaces;
using Lb_3.Classes;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        PaymentProcessor paymentProcessor = new PaymentProcessor();
        Console.WriteLine("Виберіть платіжну систему:");
        Console.WriteLine("1 - BankAccount");
        Console.WriteLine("2 - PayoneerAccount");
        Console.WriteLine("3 - WiseAccount");
        int choice = int.Parse(Console.ReadLine());
        PaymentSystemType selectedPaymentSystem = (PaymentSystemType)(choice - 1);
        Console.WriteLine("Введіть суму платежу:");
        decimal amount = decimal.Parse(Console.ReadLine());
        IPaymentSystem paymentSystem;
        switch (selectedPaymentSystem)
        {
            case PaymentSystemType.BankAccount:
                paymentSystem = new BankAccount();
                break;
            case PaymentSystemType.PayoneerAccount:
                paymentSystem = new PayoneerAccount();
                break;
            case PaymentSystemType.WiseAccount:
                paymentSystem = new WiseAccount();
                break;
            default:
                throw new ArgumentException("Невірний вибір платіжної системи.");
        }
        paymentProcessor.Process(paymentSystem, amount);
        Console.ReadLine();
    }
    public enum PaymentSystemType
    {
        BankAccount,
        PayoneerAccount,
        WiseAccount
    }

}