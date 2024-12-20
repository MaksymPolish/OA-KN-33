using Lb_2.Interfaces;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Lb_2.Classes;
public class Privat24AuthProvider: ILoginProvider
{
    private readonly string _phoneNumber;
    private readonly string _hashedPassword;

    public Privat24AuthProvider(string phoneNumber, string password)
    {
        if (! Validate(phoneNumber))
        {
            throw new ArgumentException("Invalid phone number format.");
        }

        _phoneNumber = phoneNumber;
        _hashedPassword = PasswordHasher.HashPassword(password);
    }

    public bool Validate(string login)
    {
        return Regex.IsMatch(login, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    }
}


