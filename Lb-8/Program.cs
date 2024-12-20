using Lb;

public class Program
{
    public static void Main()
    {
        var intCalculator = new Calculator<int>();
        var doubleCalculator = new Calculator<double>();

        Client.UseIntegerCalculator(intCalculator);
        Client.UseFloatingCalculator(doubleCalculator);
    }
}