using MiniBlog.Model;
using MiniBlog.Stores;

public class UserService : IUserService
{
    private IArticleStore articleStore;
    private IUserStore userStore;

    public UserService(IArticleStore articleStore, IUserStore userStore)
    {
        this.articleStore = articleStore;
        this.userStore = userStore;
    }

    public User RegisterUser(User user)
    {
        if (!userStore.GetAll().Exists(_ => user.Name.ToLower() == _.Name.ToLower()))
        {
            userStore.Save(user);
            return user;
        }
        return null;
    }

    public List<User> GetAllUsers()
    {
        return this.userStore.GetAll();
    }

    public User UpdateUserInfo(User user)
    {
        var foundUser = this.userStore.GetAll().FirstOrDefault(_ => _.Name == user.Name);
        if (foundUser == null)
        {
            return null;
        }
        foundUser.Email = user.Email;
        return foundUser;
    }

    public User DeleteUser(string name)
    {
        var foundUser = userStore.GetAll().FirstOrDefault(_ => _.Name == name);
        if (foundUser == null) { return null; }
        try
        {
            this.userStore.Delete(foundUser);
            var articles = this.articleStore.GetAll()
                .Where(article => article.UserName == foundUser.Name)
                .ToList();
            articles.ForEach(article => this.articleStore.Delete(article));
        }
        catch (Exception ex)
        {
            throw new Exception("Cannot delete due to internal error.");
        }

        return foundUser;
    }

    public User GetByName(string name)
    {
        return userStore.GetAll().FirstOrDefault(_ =>
                string.Equals(_.Name, name, StringComparison.CurrentCultureIgnoreCase)) ?? throw new
                InvalidOperationException();
    }
}