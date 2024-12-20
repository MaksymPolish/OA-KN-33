using PaternVisitor.Class;

namespace PaternVisitor;


//Інтирфейс візитіра
public interface IVisitor
{
    void Visit(Book book);
    void Visit(Magazine magazine);
}
