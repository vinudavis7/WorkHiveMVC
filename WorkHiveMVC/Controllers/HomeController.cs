using Microsoft.AspNetCore.Mvc;
using WorkHiveServices.Interface;
using WorkHiveServices;
using Helper;
using Models;
using Microsoft.CodeAnalysis;

namespace WorkHiveMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }
  


        public async Task<IActionResult> Index()
        {
            var data = await _homeService.GetDashboardData();
            return View("LandingPage", data);
        }

   

    }
}
