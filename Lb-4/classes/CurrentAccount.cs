namespace Lab_4;

public class CurrentAccount
{
    public decimal Balance { get; private set; }

    public void Credit(decimal amount) => 
        Balance += amount;

    public void Debit(decimal amount) => 
        Balance -= amount;
}