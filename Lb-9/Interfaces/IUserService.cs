using Lb_9.Entitys;

namespace Lb_9.Interfaces;

public interface IUserService
{
    void Register(User user);
    void Edit(User user);
    void Delete(int userId);
    List<User> GetAllUsers();
}