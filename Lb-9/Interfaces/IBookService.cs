using Lb_9.Entitys;

namespace Lb_9.Interfaces;

public interface IBookService
{
    void AddBook(Book book);
    void EditBook(Book updatedBook);
    void DeleteBook(int bookId);
    List<Book> GetBooksByCategory(Category category);
}