using MiniBlog.Model;

namespace MiniBlog.Services
{
    public interface IUserService
    {
        public User Register(User user);
        public User Update(User user);
        public List<User> GetAll();
        public User GetByName(string name);
        public User Delete(string name);
    }
}
