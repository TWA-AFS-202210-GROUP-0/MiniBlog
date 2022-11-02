using MiniBlog.Model;

namespace MiniBlog.Stores
{
    public class MockUserStore : IUserStore
    {
        public bool Delete(User user)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Init()
        {
            throw new NotImplementedException();
        }

        public User Save(User user)
        {
            throw new NotImplementedException();
        }
    }
}
