using Lb_9.Entitys;

namespace Lb_9;

public class Program
{
    public static void Main()
    {
        
        var container = new IoCContainer();

        var category = new Category { Id = 1, Name = "Horrors" };
        container.LibraryService.AddCategory(category);

        var category1 = new Category { Id = 2, Name = "Sci-Fi " };
        container.LibraryService.AddCategory(category1);
        
        var user = new User { Id = 1, Name = "Andrew", Email = "andrew@example.com" };
        container.LibraryService.RegisterUser(user);
        user.SubscribeToCategory(category);

        var book = new Book { Id = 1, Title = "Mounts of madness", Category = category };
        var book2 = new Book { Id = 1, Title = "Street", Category = category };
        var book3 = new Book { Id = 2, Title = "Space odyssey", Category = category1 };
        container.LibraryService.AddBook(book);
        container.LibraryService.AddBook(book2);
        container.LibraryService.AddBook(book3);
    }
}