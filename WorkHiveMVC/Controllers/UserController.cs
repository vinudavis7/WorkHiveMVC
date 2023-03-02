using Microsoft.AspNetCore.Mvc;
using Models;
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
    }
}
