using Lb_2.Interfaces;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Lb_2.Classes;
public class GmailAuthProvider: ILoginProvider
{
    private readonly string _email;
    private readonly string _hashedPassword;

    public GmailAuthProvider(string email, string password)
    {
        if (! Validate(email))
        {
            throw new ArgumentException("Invalid phone number format.");
        }
        _email = email;
        _hashedPassword = PasswordHasher.HashPassword(password);
        
    }

    public bool Validate(string login)
    {
        return Regex.IsMatch(login, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    }
}