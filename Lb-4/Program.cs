using Lab_4.Menu;

namespace Lab_4;
class Program
{
    private const string CarDealerOption = "1";
    private const string UserOption = "2";
    private const string ExitOption = "0";
    private static CarDealer[] _dealers;

    static void Main(string[] args)
    {
        var dealer = new CarDealer();
        var partnerDealer = new CarDealer();
        partnerDealer.BuyCar(new Car("Toyota", "Corolla", 2020, 20000));
        dealer.AddPartnerDealer(partnerDealer);
        
        _dealers = new[] { dealer, partnerDealer };

        var exit = false;
        while (!exit)
        {
            Console.WriteLine($"{CarDealerOption}. Car Dealer Menu");
            Console.WriteLine($"{UserOption}. User Menu");
            Console.WriteLine($"{ExitOption}. Exit");
            Console.Write("Select an option: ");

            switch (Console.ReadLine())
            {
                case CarDealerOption:
                    CarDealerMenu.Show(dealer);
                    break;
                case UserOption:
                    UserMenu.Show(_dealers);
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
}