using PaternVisitor.Class;

namespace PaternVisitor;

//Конкретний візитер
public class PriceVisitor : IVisitor
{
    void IVisitor.Visit(Magazine magazine)
    {
        Console.WriteLine($"The price of the magazine '{magazine.Title}' is {magazine.Price} USD.");
    }
    public void Visit(Book book)
    {
        Console.WriteLine($"The price of the book '{book.Title}' is {book.Price} USD.");
    }
}
