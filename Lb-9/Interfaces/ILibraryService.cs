using Lb_9.Entitys;

namespace Lb_9.Interfaces;

public interface ILibraryService
{
    void AddBook(Book book);
    void AddCategory(Category category);
    void RegisterUser(User user);
}