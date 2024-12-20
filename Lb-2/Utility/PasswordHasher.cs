using System.Security.Cryptography;
using System.Text;

namespace Lb_2.Classes
{
    public static class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }

        public static bool IsPasswordMatchingHash(string password, string hash)
        {
            string hashedInput = HashPassword(password);
            return hashedInput == hash;
        }
    }
}