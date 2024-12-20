namespace PaternVisitor;

//Інтирфейс елементів 
public interface IElement
{
    void Accept(IVisitor visitor);
}