using MiniBlog.Model;
using MiniBlog.Stores;
using Microsoft.AspNetCore.Mvc;

namespace MiniBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public ActionResult<User> Register(User user)
        {
            var newUser = this.userService.RegisterUser(user);

            var actionName = nameof(GetByName);
            var routeValue = new { name = user.Name };
            return newUser != null ? CreatedAtAction(actionName, routeValue, user) : StatusCode(500);
        }

        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            var users = this.userService.GetAllUsers();
            return users != null ? Ok(users) : NoContent();
        }

        [HttpPut]
        public ActionResult<User> Update(User user)
        {
            var foundUser = userService.UpdateUserInfo(user);

            return foundUser != null ? Ok(User) : NotFound();
        }

        [HttpDelete]
        public ActionResult<User> Delete(string name)
        {
            User foundUser = null;
            try
            {
                foundUser = this.userService.DeleteUser(name);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }

            return foundUser != null ? Ok(foundUser) : NotFound(foundUser);
        }

        [HttpGet("{name}")]
        public ActionResult<User> GetByName(string name)
        {
            User user = null;
            try
            {
                user = this.userService.GetByName(name);
            }catch (InvalidOperationException ex)
            {
                return StatusCode(500);
            }
            return user != null ? Ok(user) : NotFound(user);
        }
    }
}