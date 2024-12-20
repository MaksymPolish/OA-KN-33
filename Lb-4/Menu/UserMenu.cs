namespace Lab_4.Menu;

public static class UserMenu
{
    
    private const string BuyCarOption = "1";
    private const string ExitOption = "0";
    public static void Show(CarDealer[] dealers)
    {
        Console.Write("Enter your name: ");
        var name = Console.ReadLine();
        Console.Write("Enter initial account balance: ");
        var balance = decimal.Parse(Console.ReadLine());

        var user = new User(name, balance);

        var exit = false;
        while (!exit)
        {
            Console.WriteLine($"{BuyCarOption}. Buy Car");
            Console.WriteLine($"{ExitOption}. Back");
            Console.Write("Select an option: ");

            switch (Console.ReadLine())
            {
                case BuyCarOption:
                    BuyCar(user, dealers);
                    break;
                case ExitOption:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
    
    private static void BuyCar(User user, IEnumerable<CarDealer> dealers)
    {
        Console.Write("Enter car make: ");
        var make = Console.ReadLine();
        Console.Write("Enter car model: ");
        var model = Console.ReadLine();

        foreach (var dealer in dealers)
        {
            var cars = dealer.SearchCars(make, model);
            if (cars.Count <= 0) 
                continue;
            
            Console.WriteLine("Cars available:");
            for (var i = 0; i < cars.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {cars[i]}");
            }
            Console.Write("Select a car to buy: ");
            var selectedIndex = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException()) - 1;
            if (selectedIndex >= 0 && selectedIndex < cars.Count)
            {
                user.BuyCar(dealer, cars[selectedIndex]);
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
            return;
        }

        Console.WriteLine("Car not found.");
    }
}