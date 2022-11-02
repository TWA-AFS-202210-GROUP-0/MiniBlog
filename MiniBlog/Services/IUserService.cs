namespace MiniBlog.Services
{
    using MiniBlog.Model;

    public interface IUserService
    {
        User Register(User user);
        List<User> GetAll();
        User Update(User user);
        User GetByName(string name);
        User Delete(string name);
    }
}