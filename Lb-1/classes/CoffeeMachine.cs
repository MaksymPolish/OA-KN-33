using Lb_1.interfaces;

namespace Lb_1.Classes
{
    public class CoffeeMachine : ICoffeeMachine
    {
        public int WaterAmount { get; private set; }
        public int CoffeeBeansAmount { get; private set; }
        public bool IsWaterHeated { get; private set; }

        public CoffeeMachine(int waterAmount, int coffeeBeansAmount)
        {
            WaterAmount = waterAmount;
            CoffeeBeansAmount = coffeeBeansAmount;
            IsWaterHeated = false;
        }

        public void MakeEspresso()
        {
            const int espressoBeans = 20;
            const int espressoWater = 30;

            if (CoffeeBeansAmount < espressoBeans)
            {
                Console.WriteLine("Недостатньо кавових зерен для еспресо!");
                return;
            }

            if (WaterAmount < espressoWater)
            {
                Console.WriteLine("Недостатньо води для еспресо!");
                return;
            }

            HeatWater();
            GrindBeans(espressoBeans);
            UseWater(espressoWater);
            Console.WriteLine("Ваш еспресо готовий!");
        }

        public void MakeLatte()
        {
            const int latteBeans = 25;
            const int latteWater = 50;

            if (CoffeeBeansAmount < latteBeans)
            {
                Console.WriteLine("Недостатньо кавових зерен для латте!");
                return;
            }

            if (WaterAmount < latteWater)
            {
                Console.WriteLine("Недостатньо води для латте!");
                return;
            }

            HeatWater();
            GrindBeans(latteBeans);
            UseWater(latteWater);
            Console.WriteLine("Ваше латте готове!");
        }

        private void HeatWater()
        {
            if (!IsWaterHeated)
            {
                Console.WriteLine("Нагрiвання води...");
                IsWaterHeated = true;
            }
        }

        private void GrindBeans(int amount)
        {
            if (CoffeeBeansAmount >= amount)
            {
                Console.WriteLine($"Змелюємо {amount} грам кавових зерен...");
                CoffeeBeansAmount -= amount;
            }
        }

        private void UseWater(int amount)
        {
            if (WaterAmount >= amount)
            {
                Console.WriteLine($"Використовуємо {amount} мл води...");
                WaterAmount -= amount;
            }
        }
    }
}