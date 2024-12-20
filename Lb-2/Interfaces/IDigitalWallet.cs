namespace Lb_2.Interfaces;

public interface IDigitalWallet
{
    decimal CheckBalance(); 
    List<string> GetTransactionLog();
    bool Withdraw(decimal amount);
    void Deposit(decimal amount);
    void SetAuthProvider(ILoginProvider authProvider);
}