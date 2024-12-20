namespace Lab_4;

public interface ICarDealer
{
    List<Car> SearchCars(string make, string model);
    bool ExchangeCar(Car offeredCar, Car requestedCar);
}