using Lb_9.Entitys;
using Lb_9.Interfaces;

namespace Lb_9.Services;

public class BookService : IBookService
{
    private readonly List<Book> _books = new();

    public void AddBook(Book book)
    {
        if (book == null) throw new ArgumentNullException(nameof(book), "Book parameter cannot be null.");
        _books.Add(book);
    }

    public List<Book> GetBooksByCategory(Category category)
    {
        if (category == null) throw new ArgumentNullException(nameof(category));
        return _books.Where(b => b.Category.Name == category.Name).ToList();
    }

    public void DeleteBook(int bookId)
    {
        var book = _books.FirstOrDefault(b => b.Id == bookId);
        if (book == null) throw new Exception("Book does not exist.");

        _books.Remove(book);
    }
    
    public void EditBook(Book updatedBook)
    {
        if (updatedBook == null) throw new ArgumentNullException(nameof(updatedBook));
        var existingBook = _books.FirstOrDefault(b => b.Id == updatedBook.Id);
        if (existingBook == null) throw new Exception("Book does not exist.");

        existingBook.Title = updatedBook.Title;
        existingBook.Author = updatedBook.Author;
        existingBook.Category = updatedBook.Category;
    }
}