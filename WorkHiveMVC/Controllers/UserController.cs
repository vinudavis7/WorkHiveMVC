using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using WorkHiveServices.Interface;

namespace WorkHiveMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserservice _userservice;
        public UserController(IUserservice userService)
        {
            _userservice = userService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Users()
        {
           var usersList= _userservice.GetUsers();
            return View(usersList);
        }
        public async Task<IActionResult> UserList()
        {
            var usersList = await _userservice.GetUsers();
            return View(usersList);
        }
        public async Task<string> Login(string username, string password)
        {
            var user = await _userservice.GetUserDetails(username, password);
            if (user != null)
            {
                HttpContext.Session.SetString("loggedInUserId", user.UserId.ToString());
                HttpContext.Session.SetString("loggedInUserType", user.UserType);
                HttpContext.Session.SetString("loggedInUserName", user.Name);

                return user.UserType;
                
            }else
                return "Failed";
           
        }
        public  IActionResult Logout()
        {

                HttpContext.Session.SetString("loggedInUserId", String.Empty);
                HttpContext.Session.SetString("loggedInUserType", String.Empty);
                HttpContext.Session.SetString("loggedInUserName", String.Empty);
            return RedirectToAction("Index", "Jobs");

        }
        [HttpPost]
        public async Task<bool> Register([FromBody]  User user)
        {
            //user.ProfileImage = "asd";
            //user.Email = "asf";
           // user.UserType = "admin";
            var result = await _userservice.Register(user);
            if (result)
            {
               return true;

            }
            else
                return false;
        }
    }
}
