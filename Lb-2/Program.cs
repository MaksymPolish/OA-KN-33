using Lb_2.Interfaces;
using Lb_2.Classes;
using System.Security.Cryptography;
using System.Text;
using System;
using System.Collections.Generic;

class Program
{
    private enum AuthenticationChoice : int
    {
        Gmail = 1,
        Privat24 = 2
    }

    private enum WalletOption : int
    {
        CheckBalance = 1,
        Deposit = 2,
        Withdraw = 3,
        TransactionHistory = 4,
        Exit = 5
    }
    private static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        while (true)
        {
            Console.WriteLine("Welcome! Please log in to the system:");
            Console.WriteLine("Choose an authentication method:");
            Console.WriteLine($"{(int)AuthenticationChoice.Gmail}. Authenticate via email (Gmail)");
            Console.WriteLine($"{(int)AuthenticationChoice.Privat24}. Authenticate via phone number (Privat24)");
            Console.Write("Your choice: ");

            string choice = Console.ReadLine();

            HandleAuthenticationChoice(choice);
        }
    }

    private static void HandleAuthenticationChoice(string choice)
    {
        switch ((AuthenticationChoice)Enum.Parse(typeof(AuthenticationChoice), choice))
        {
            case AuthenticationChoice.Gmail:
                AuthenticateViaGmail();
                break;
            case AuthenticationChoice.Privat24:
                AuthenticateViaPrivat24();
                break;
            default:
                Console.WriteLine("Invalid choice");
                break;
        }
    }

    private static void AuthenticateViaGmail()
    {
        Console.Write("Email: ");
        string email = Console.ReadLine();
        Console.Write("Password: ");
        string password = Console.ReadLine();
        ILoginProvider authProvider = new GmailAuthProvider(email, password);
        DigitalWallet wallet = new DigitalWallet(email, password);
        wallet.SetAuthProvider(authProvider);
        Authenticate(wallet);
    }

    private static void AuthenticateViaPrivat24()
    {
        Console.Write("Phone number: ");
        string phoneNumber = Console.ReadLine();
        Console.Write("Password: ");
        string phonePassword = Console.ReadLine();
        ILoginProvider authProvider = new Privat24AuthProvider(phoneNumber, phonePassword);
        DigitalWallet wallet = new DigitalWallet(phoneNumber, phonePassword);
        wallet.SetAuthProvider(authProvider);
        Authenticate(wallet);
    }

    private static void Authenticate(DigitalWallet wallet)
    {
        bool isAuthenticated = false;

        while (!isAuthenticated)
        {
            Console.Write("Email/Phone number: ");
            string login = Console.ReadLine();
            Console.Write("Password: ");
            string enteredPassword = Console.ReadLine();

            isAuthenticated = wallet.Authenticate(login, enteredPassword);

            if (!isAuthenticated)
            {
                Console.WriteLine("Incorrect credentials. Please try again.");
            }
        }

        Console.WriteLine("Successfully logged in!");
        HandleWalletOptions(wallet);
    }

    private static void HandleWalletOptions(DigitalWallet wallet)
    {
        while (true)
        {
            PrintMenuWalletOptions();

            string option = Console.ReadLine();

            if (Enum.TryParse(option, out WalletOption selectedOption))
            {
                switch (selectedOption)
                {
                    case WalletOption.CheckBalance:
                        Console.WriteLine($"Your balance: {wallet.CheckBalance():C}");
                        break;
                    case WalletOption.Deposit:
                        HandleDeposit(wallet);
                        break;
                    case WalletOption.Withdraw:
                        HandleWithdrawal(wallet);
                        break;
                    case WalletOption.TransactionHistory:
                        DisplayTransactionLog(wallet);
                        break;
                    case WalletOption.Exit:
                        Console.WriteLine("Thank you for using the system! Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid option");
            }

            Console.WriteLine();
        }
    }

    private static void PrintMenuWalletOptions()
    {
        Console.WriteLine("Choose an option:");
        Console.WriteLine($"{(int)WalletOption.CheckBalance}. Check balance");
        Console.WriteLine($"{(int)WalletOption.Deposit}. Deposit funds");
        Console.WriteLine($"{(int)WalletOption.Withdraw}. Withdraw funds");
        Console.WriteLine($"{(int)WalletOption.TransactionHistory}. View transaction history");
        Console.WriteLine($"{(int)WalletOption.Exit}. Exit");
        Console.Write("Your choice: ");
    }

    private static void HandleDeposit(DigitalWallet wallet)
    {
        Console.Write("Enter the deposit amount: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount))
        {
            wallet.Deposit(depositAmount);
            Console.WriteLine($"Balance topped up by {depositAmount:C}");
            return;
        }
        Console.WriteLine("Invalid amount");
    }

    private static void HandleWithdrawal(DigitalWallet wallet)
    {
        Console.Write("Enter the withdrawal amount: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount))
        {
            try
            {
                if (wallet.Withdraw(withdrawAmount))
                {
                    Console.WriteLine($"Withdrawn {withdrawAmount:C} from your account");
                    return;
                }
                Console.WriteLine("Insufficient funds in your account");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return;
            }
        }
        Console.WriteLine("Invalid amount");
    }

    private static void DisplayTransactionLog(DigitalWallet wallet)
    {
        var transactionLog = wallet.GetTransactionLog();
        Console.WriteLine("Transaction history:");
        foreach (var transaction in transactionLog)
        {
            Console.WriteLine(transaction);
        }
    }
}
