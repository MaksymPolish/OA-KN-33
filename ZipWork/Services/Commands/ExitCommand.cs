namespace ZipWork.Services.Commands;

public class ExitCommand : Interfaces.ICommand
{
    public void Execute()
    {
        Console.WriteLine("Exit");
        Environment.Exit(0);
    }
}