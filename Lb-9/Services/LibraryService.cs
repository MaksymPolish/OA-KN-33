using Lb_9.Entitys;
using Lb_9.Interfaces;

namespace Lb_9.Services;

public class LibraryService : ILibraryService
{
    private readonly IBookService _bookService;
    private readonly ICategoryService _categoryService;
    private readonly INotificationService _notificationService;
    private readonly IUserService _userService;

    public LibraryService(IUserService userService,
        INotificationService notificationService,
        IBookService bookService,
        ICategoryService categoryService)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
        _bookService = bookService ?? throw new ArgumentNullException(nameof(bookService));
        _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
    }

    public void AddBook(Book book)
    {
        _bookService.AddBook(book);
        NotifyUsers(book);
    }

    public void AddCategory(Category category)
    {
        _categoryService.Add(category);
    }

    public void RegisterUser(User user)
    {
        _userService.Register(user);
    }

    public void NotifyUsers(Book book)
    {
        var users = _userService.GetAllUsers()
            .Where(u => u.SubscribedCategories.Contains(book.Category));

        foreach (var user in users)
        {
            try
            {
                _notificationService.SendEmail(user, $"New book added in {book.Category.Name}: {book.Title}");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error");
            }
        }
    }

    public void EditBook(Book updatedBook)
    {
        _bookService.EditBook(updatedBook);
    }

    public void DeleteBook(int bookId)
    {
        _bookService.DeleteBook(bookId);
    }

    public List<Book> GetBooksByCategory(Category category)
    {
        return _bookService.GetBooksByCategory(category);
    }

    public void EditCategory(Category category)
    {
        _categoryService.Edit(category);
    }

    public void DeleteCategory(int categoryId)
    {
        _categoryService.Delete(categoryId);
    }

    public List<Category> GetAllCategories()
    {
        return _categoryService.GetAllCategories();
    }

    public List<User> GetAllUsers()
    {
        return _userService.GetAllUsers();
    }

    public void EditUser(User user)
    {
        _userService.Edit(user);
    }

    public void DeleteUser(int userId)
    {
        _userService.Delete(userId);
    }
}