namespace PaternVisitor.Class;

public class Magazine : IElement
{
    public string Title { get; set; }
    public double Price { get; set; }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}