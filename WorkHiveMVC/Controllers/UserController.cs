using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.ViewModel;
using WorkHiveServices.Interface;

namespace WorkHiveMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userservice;
        public UserController(IUserService userService)
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
            username = "vinudavis8@gmail.com";
            username = "cc@gmail.com";
            //username = "admin@gmail.com";

            password = "1234";
            password = "@Lucifer666";
            var user = await _userservice.Login(username, password);
            if (user != null)
            {
                HttpContext.Session.SetString("loggedInUserId", user.UserId);
                HttpContext.Session.SetString("loggedInUserType", user.Role);
                HttpContext.Session.SetString("loggedInUserName", user.Name);

                return user.Role;
                
            }else
                return "Failed";
           
        }
        public  IActionResult Logout()
        {

                HttpContext.Session.SetString("loggedInUserId", String.Empty);
                HttpContext.Session.SetString("loggedInUserType", String.Empty);
                HttpContext.Session.SetString("loggedInUserName", String.Empty);
            return RedirectToAction("Index", "Home");

        }
        [HttpPost]
        public async Task<bool> Register([FromBody] RegisterRequest user)
        {

            var result = await _userservice.Register(user);

            return true;
        }
    }
}
