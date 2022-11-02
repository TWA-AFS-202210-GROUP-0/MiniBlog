using MiniBlog.Model;
using MiniBlog.Stores;
using Microsoft.AspNetCore.Mvc;
using MiniBlog.Services;

namespace MiniBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IArticleStore _articleStore;
        private readonly IUserStore _userStore;
        private IUserService _userService;
        public UserController(IArticleStore articleStore, IUserStore userStore, IUserService userService)
        {
            _articleStore = articleStore;
            _userStore = userStore;
            _userService = userService;
        }
        [HttpPost]
        public ActionResult<User> Register(User user)
        {
            

            return Created($"/user/{user.Name}", _userService.Register(user));
        }

        [HttpGet]
        public List<User> GetAll()
        {
            return _userService.GetAll();
        }

        [HttpPut]
        public User Update(User user)
        {
            return _userService.Update(user);
        }

        [HttpDelete]
        public User Delete(string name)
        {
            var foundUser = _userStore.GetAll().FirstOrDefault(_ => _.Name == name);
            if (foundUser != null)
            {
                _userStore.Delete(foundUser);
                var articles = _articleStore.GetAll()
                    .Where(article => article.UserName == foundUser.Name)
                    .ToList();
                articles.ForEach(article => _articleStore.Delete(article));
            }

            return foundUser;
        }

        [HttpGet("{name}")]
        public User GetByName(string name)
        {
            return _userService.GetByName(name);
        }

        
    }
}