using System.Numerics;

namespace Lb
{
    public class Calculator<T> where T : INumber<T>
    {
        public T Add(T a, T b) => a + b;
        public T Subtract(T a, T b) => a - b;
        public T Multiply(T a, T b) => a * b;
        public T Divide(T a, T b) => a / b;
        public T Pow(T a, T b)
        {
            T result = T.One;
            for (T i = T.Zero; i < b; i++)
            {
                result *= a;
            }
            return result;
        }
    }
}