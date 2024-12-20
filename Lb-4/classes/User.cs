namespace Lab_4;

public class User
{
    public string Name { get; set; }
    public CurrentAccount Account { get; private set; } = new();

    public User(string name, decimal initialBalance)
    {
        Name = name;
        Account.Credit(initialBalance);
    }

    public void BuyCar(CarDealer dealer, Car car)
    {
        var cars = dealer.SearchCars(car.Make, car.Model);
        if (cars.Count == 0)
        {
            Console.WriteLine("Car not found.");
            return;
        }

        var selectedCar = cars[0];
        if (Account.Balance >= selectedCar.Price)
        {
            Account.Debit(selectedCar.Price);
            dealer.SellCar(selectedCar);
            Console.WriteLine($"Successfully bought {selectedCar}");
        }
        else
        {
            Console.WriteLine("Insufficient balance to buy the car.");
        }
    }
}
