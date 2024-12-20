namespace Lab_4;

public class Car
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public decimal Price { get; set; }

    public Car(string make, string model, int year, decimal price)
    {
        Make = make;
        Model = model;
        Year = year;
        Price = price;
    }

    public override string ToString() => 
        $"{Year} {Make} {Model}, Price: ${Price}";
}