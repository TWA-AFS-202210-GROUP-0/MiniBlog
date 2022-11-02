namespace MiniBlog.Services
{
    using MiniBlog.Model;

    public interface IUserService
    {
        User Register(User user);
    }
}