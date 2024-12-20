using Lb_2.Interfaces;
using System;
using System.Collections.Generic;

namespace Lb_2.Classes
{
    public class DigitalWallet : IDigitalWallet
    {
        private bool isAuthenticated = false;
        private decimal _balance;
        private readonly string _login;
        private readonly string _hashedPassword;
        private ILoginProvider _authProvider;
        private List<string> _transactionLog;

        public DigitalWallet(string login, string password)
        {
            _login = login;
            _hashedPassword = PasswordHasher.HashPassword(password);
            _transactionLog = new List<string>();
        }

        public void SetAuthProvider(ILoginProvider authProvider)
        {
            _authProvider = authProvider;
        }

        public decimal CheckBalance()
        {
            EnsureAuthenticated();
            return _balance;
        }

        public void Deposit(decimal amount)
        {
            EnsureAuthenticated();
            _balance += amount;
            _transactionLog.Add($"Deposited {amount:C}");
        }

        public bool Withdraw(decimal amount)
        {
            EnsureAuthenticated();
            if (_balance >= amount)
            {
                _balance -= amount;
                _transactionLog.Add($"Withdrawn {amount:C}");
                return true;
            }
            return false;
        }

        public List<string> GetTransactionLog()
        {
            EnsureAuthenticated();
            return _transactionLog;
        }

        public bool Authenticate(string login, string password)
        {
            if (_authProvider == null)
            {
                throw new InvalidOperationException("Auth provider is not set.");
            }

            if (_authProvider.Validate(login) &&
                login == _login &&
                PasswordHasher.IsPasswordMatchingHash(password, _hashedPassword))
            {
                isAuthenticated = true;
                return true;
            }

            isAuthenticated = false;
            throw new UnauthorizedAccessException("Invalid credentials");
        }

        private void EnsureAuthenticated()
        {
            if (!isAuthenticated)
            {
                throw new UnauthorizedAccessException("You are not authenticated.");
            }
        }
    }
}
