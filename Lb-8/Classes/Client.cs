using System.Numerics;

namespace Lb
{
    public class Client
    {
        public static void UseIntegerCalculator<T>(Calculator<T> calculator) where T : INumber<T>
        {
            Console.WriteLine("Integer Calculator Add: " + calculator.Add((T)Convert.ChangeType(5, typeof(T)), (T)Convert.ChangeType(10, typeof(T))));
            Console.WriteLine("Integer Calculator Multiply: " + calculator.Multiply((T)Convert.ChangeType(3, typeof(T)), (T)Convert.ChangeType(4, typeof(T))));
        }

        public static void UseFloatingCalculator<T>(Calculator<T> calculator) where T : INumber<T>
        {
            Console.WriteLine("Floating Calculator Divide: " + calculator.Divide((T)Convert.ChangeType(9.0, typeof(T)), (T)Convert.ChangeType(3.0, typeof(T))));
            Console.WriteLine("Floating Calculator Pow: " + calculator.Pow(T.CreateChecked(4.0),T.CreateChecked(6.0)));
        }
    }
}