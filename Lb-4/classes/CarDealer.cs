namespace Lab_4;

public class CarDealer : ICarDealer
{
    public Inventory Inventory { get; private set; } = new();
    public CurrentAccount Account { get; private set; } = new();
    private readonly List<ICarDealer> _partnerDealers = new();
    private decimal _markupPercentage = 0;

    public void AddPartnerDealer(ICarDealer dealer) => 
        _partnerDealers.Add(dealer);

    public void BuyCar(Car car)
    {
        Inventory.AddCar(car);
        Account.Debit(car.Price);
    }

    public void SellCar(Car car)
    {
        var salePrice = car.Price * (1 + _markupPercentage / 100);
        Inventory.RemoveCar(car);
        Account.Credit(salePrice);
    }

    public List<Car> SearchCars(string make, string model)
    {
        var foundCars = Inventory.GetCars().FindAll(car => car.Make == make && car.Model == model);

        if (foundCars.Count != 0) 
            return foundCars;
        
        foreach (var dealer in _partnerDealers) 
            foundCars.AddRange(dealer.SearchCars(make, model));

        return foundCars;
    }

    public bool ExchangeCar(Car offeredCar, Car requestedCar)
    {
        foreach (var dealer in _partnerDealers)
        {
            var dealerCars = dealer.SearchCars(requestedCar.Make, requestedCar.Model);
            foreach (var car in dealerCars)
            {
                if (car.Model != requestedCar.Model || car.Make != requestedCar.Make) 
                    continue;
                
                var difference = car.Price - offeredCar.Price;

                if (difference <= 0 || Account.Balance < difference) 
                    continue;
                
                Inventory.RemoveCar(offeredCar);
                dealer.ExchangeCar(car, offeredCar);
                Inventory.AddCar(car);
                Account.Debit(difference);
                return true;
            }
        }
        
        return false;
    }
    
    public void SetMarkupPercentage(decimal percentage) => 
        _markupPercentage = percentage;
}