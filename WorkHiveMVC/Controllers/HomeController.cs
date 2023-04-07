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

        public async Task<ActionResult> Index()
        {
            try
            {
                var data = await _homeService.GetDashboardData();
                return View("LandingPage", data);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public ActionResult Error()
        {
            return View();
        }



    }
}
