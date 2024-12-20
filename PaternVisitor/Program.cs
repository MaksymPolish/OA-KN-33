using PaternVisitor;
using PaternVisitor.Class;

public class Program
{
    public static void Main()
    {
        IElement book = new Book { Title = "C# Programming", Price = 29.99 };
        IElement magazine = new Magazine { Title = "Tech Magazine", Price = 5.99 };

        IVisitor priceVisitor = new PriceVisitor();

        // Виклик метода Accept, щоб візитер "відвідав" елементи
        book.Accept(priceVisitor);   // The price of the book 'C# Programming' is 29.99 USD.
        magazine.Accept(priceVisitor); // The price of the magazine 'Tech Magazine' is 5.99 USD.
    }
}