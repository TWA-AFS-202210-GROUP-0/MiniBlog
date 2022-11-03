namespace MiniBlog.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MiniBlog.Model;
    using MiniBlog.Services;

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private UserService _userService;
        
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ActionResult<User> Register(User user)
        {

            var newUser = _userService.Register(user);
            var actionName = nameof(GetByName);
            var routeValue = new { name = user.Name };
            return CreatedAtAction(actionName, routeValue, newUser);
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
            return _userService.Delete(name);
        } 

        [HttpGet("{name}")]
        public User GetByName(string name)
        {
            return _userService.GetByName(name);
        }
    }
}