namespace Lab_4;

public class Inventory
{
    private readonly List<Car> _cars = new();

    public void AddCar(Car car) => 
        _cars.Add(car);

    public void RemoveCar(Car car) => 
        _cars.Remove(car);

    public List<Car> GetCars() => 
        _cars;

    public Car? FindCarByModel(string model) => 
        _cars.Find(car => car.Model == model);
}