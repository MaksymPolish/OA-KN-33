using Xunit;
using Assert = Xunit.Assert;

namespace Lb
{
    public class CalculatorTests
    {
        private readonly Calculator<int> intCalculator;
        private readonly Calculator<double> doubleCalculator;
        private readonly Calculator<decimal> decimalCalculator;

        public CalculatorTests()
        {
            intCalculator = new Calculator<int>();
            doubleCalculator = new Calculator<double>();
            decimalCalculator = new Calculator<decimal>();
        }

        [Fact]
        public void AddTest()
        {
            Assert.Equal(5, intCalculator.Add(2, 3));
        }

        [Fact]
        public void SubtractTest()
        {
            Assert.Equal(1, intCalculator.Subtract(3, 2));
        }

        [Fact]
        public void MultiplyTest()
        {
            Assert.Equal(6.0, doubleCalculator.Multiply(2.0, 3.0));
        }

        [Fact]
        public void DivideTest()
        {
            Assert.Equal(2.0m, decimalCalculator.Divide(4.0m, 2.0m));
        }

        [Fact]
        public void PowTest()
        {
            Assert.Equal(8.0, doubleCalculator.Pow(2.0, 3));
        }

        [Fact]
        public void DivideByZeroTest()
        {
            Assert.Throws<DivideByZeroException>(() => intCalculator.Divide(5, 0));
        }
    }
}