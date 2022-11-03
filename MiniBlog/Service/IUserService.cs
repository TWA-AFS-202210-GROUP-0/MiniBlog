using MiniBlog.Model;

namespace MiniBlog.Service
{
    public interface IUserService
    {
        User Register(User user);
        User Update(User user);
        User Delete(string name);
        User GetByName(string name);

        List<User> GetAll();
    }
}
