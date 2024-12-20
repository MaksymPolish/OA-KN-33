using Lb_1.Classes;
using Lb_1.interfaces;

ICoffeeMachine coffeeMachine = new CoffeeMachine(1000, 100);
Console.OutputEncoding = System.Text.Encoding.UTF8;

while (true)
{
    Console.WriteLine();
    Console.WriteLine("Кавова машина:");
    Console.WriteLine($"Кiлькiсть води: {coffeeMachine.WaterAmount} мл");
    Console.WriteLine($"Кiлькiсть кавових зерен: {coffeeMachine.CoffeeBeansAmount} грам");
    Console.WriteLine($"Чи нагрiта вода: " + (coffeeMachine.IsWaterHeated ? "Так нагріта" : "Нi не нагрiта"));
    Console.WriteLine();
    Console.WriteLine("Оберiть дiю:");
    Console.WriteLine("1. Зробити еспресо");
    Console.WriteLine("2. Зробити латте");
    Console.WriteLine("3. Переглянути стан кавової машини");
    Console.WriteLine("4. Вийти");

    string input = Console.ReadLine();

    if (Enum.TryParse(input, true, out CoffeeMachineAction action))
    {
        switch (action)
        {
            case CoffeeMachineAction.MakeEspresso:
                coffeeMachine.MakeEspresso();
                Console.WriteLine("нажмiть любу клавiшу щоб продовжити");
                Console.ReadLine();
                break;
            case CoffeeMachineAction.MakeLatte:
                coffeeMachine.MakeLatte();
                Console.WriteLine("нажмiть любу клавiшу щоб продовжити");
                Console.ReadLine();
                break;
            case CoffeeMachineAction.CheckStatus:
                Console.WriteLine("Поточний стан кавової машини:");
                Console.WriteLine($"Кiлькiсть води: {coffeeMachine.WaterAmount} мл");
                Console.WriteLine($"Кiлькiсть кавових зерен: {coffeeMachine.CoffeeBeansAmount} грам");
                Console.WriteLine($"Чи нагрiта вода: " + (coffeeMachine.IsWaterHeated ? "Так нагріта" : "Нi не нагрiта"));
                Console.WriteLine("нажмiть любу клавiшу щоб продовжити");
                Console.ReadLine();
                break;
            case CoffeeMachineAction.Exit:
                Console.WriteLine("Вихід...");
                return;
            default:
                Console.WriteLine("Невiрний вибiр. Спробуйте ще раз.");
                Console.WriteLine("нажмiть любу клавiшу щоб продовжити");
                Console.ReadLine();
                break;
        }
    }
    else
    {
        Console.WriteLine("Невiрний вибiр. Спробуйте ще раз.");
        Console.WriteLine("нажмiть любу клавiшу щоб продовжити");
        Console.ReadLine();
    }

    Console.Clear();
}

public enum CoffeeMachineAction
{
    MakeEspresso = 1,
    MakeLatte = 2,
    CheckStatus = 3,
    Exit = 4
}
