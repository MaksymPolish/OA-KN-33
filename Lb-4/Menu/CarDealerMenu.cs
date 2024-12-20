namespace Lab_4.Menu;

public static class CarDealerMenu
{
    private const string BuyCarOption = "1";
    private const string SellCarOption = "2";
    private const string ExchangeCarOption = "3";
    private const string ViewInventoryOption = "4";
    private const string ViewAccountBalanceOption = "5";
    private const string SetMarkupPercentageOption = "6";
    private const string ExitOption = "0";

    public static void Show(CarDealer dealer)
    {
        var exit = false;
        while (!exit)
        {
            ShowMenuOptions();

            switch (Console.ReadLine())
            {
                case BuyCarOption:
                    BuyCar(dealer);
                    break;
                case SellCarOption:
                    SellCar(dealer);
                    break;
                case ExchangeCarOption:
                    ExchangeCar(dealer);
                    break;
                case ViewInventoryOption:
                    ViewInventory(dealer);
                    break;
                case ViewAccountBalanceOption:
                    ViewAccountBalance(dealer);
                    break;
                case SetMarkupPercentageOption:
                    SetMarkupPercentage(dealer);
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

    private static void ShowMenuOptions()
    {
        Console.WriteLine($"{BuyCarOption}. Buy Car");
        Console.WriteLine($"{SellCarOption}. Sell Car");
        Console.WriteLine($"{ExchangeCarOption}. Exchange Car");
        Console.WriteLine($"{ViewInventoryOption}. View Inventory");
        Console.WriteLine($"{ViewAccountBalanceOption}. View Account Balance");
        Console.WriteLine($"{SetMarkupPercentageOption}. Set Markup Percentage");
        Console.WriteLine($"{ExitOption}. Back to Main Menu");
        Console.Write("Select an option: ");
    }

    private static void BuyCar(CarDealer dealer)
    {
        Console.Write("Enter make: ");
        var make = Console.ReadLine();

        Console.Write("Enter model: ");
        var model = Console.ReadLine();

        Console.Write("Enter year: ");
        var year = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

        Console.Write("Enter price: ");
        var price = decimal.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

        if (make != null && model != null)
        {
            var car = new Car(make, model, year, price);
            dealer.BuyCar(car);
        }

        Console.WriteLine("Car added to inventory.");
    }

    private static void SellCar(CarDealer dealer)
    {
        Console.Write("Enter model of the car to sell: ");
        var model = Console.ReadLine();

        if (model == null) 
            return;
        
        var car = dealer.Inventory.FindCarByModel(model);
        if (car != null)
        {
            dealer.SellCar(car);
            Console.WriteLine("Car sold.");
        }
        else
        {
            Console.WriteLine("Car not found.");
        }
    }
    
    private static void ExchangeCar(CarDealer dealer)
    {
        Console.Write("Enter model of the car to offer: ");
        var offerModel = Console.ReadLine();

        Console.Write("Enter make of the car to request: ");
        var requestMake = Console.ReadLine();

        Console.Write("Enter model of the car to request: ");
        var requestModel = Console.ReadLine();

        if (offerModel == null) 
            return;
        var offeredCar = dealer.Inventory.FindCarByModel(offerModel);
        
        if (requestMake == null || requestModel == null) 
            return;
        
        var requestedCar = new Car(requestMake, requestModel, 0, 0);
        if (offeredCar != null)
        {
            Console.WriteLine(dealer.ExchangeCar(offeredCar, requestedCar)
                ? "Car exchange successful."
                : "Car exchange failed.");
        }
        else
        {
            Console.WriteLine("Offered car not found.");
        }
    }

    private static void ViewInventory(CarDealer dealer)
    {
        foreach (var car in dealer.Inventory.GetCars()) 
            Console.WriteLine(car);
    }

    private static void ViewAccountBalance(CarDealer dealer) => 
        Console.WriteLine($"Current balance: ${dealer.Account.Balance}");
    
    private static void SetMarkupPercentage(CarDealer dealer)
    {
        Console.Write("Enter markup percentage: ");
        var percentage = decimal.Parse(Console.ReadLine());

        dealer.SetMarkupPercentage(percentage);
        Console.WriteLine($"Markup percentage set to {percentage}%.");
    }
}