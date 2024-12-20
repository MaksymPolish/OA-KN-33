using System.Linq;

class Program
{
    static void Main()
    {
        string str = "a, 1, 2, f, -1, 0, 4, 10, 4, 4f, 8, 9, 3";
        var numbers = str.Split(',')
            .Select(x => 
            {
                double result;
                return double.TryParse(x.Trim(), out result) ? (double?)result : null;
            })
            .Where(x => x.HasValue)
            .Select(x => x.Value)
            .OrderBy(x => x) 
            .Skip(3)        
            .ToList();
        
        double sum = numbers.Sum();
        
        Console.WriteLine($"Сума чисел без 3 найменших: {sum}");
    }
}