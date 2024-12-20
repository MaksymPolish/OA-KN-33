using Lb_9.Entitys;

namespace Lb_9.Interfaces;

public interface ICategoryService
{
    void Add(Category category);
    void Edit(Category category);
    void Delete(int categoryId);
    List<Category> GetAllCategories();
}