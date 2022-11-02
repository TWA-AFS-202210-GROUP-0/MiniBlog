using MiniBlog.Model;

public interface IUserService
{
    User DeleteUser(string name);
    List<User> GetAllUsers();
    User GetByName(string name);
    User RegisterUser(User user);
    User UpdateUserInfo(User user);
}