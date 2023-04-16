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
        private readonly ILogger<HomeController> _logger;

        private readonly IHomeService _homeService;

        public HomeController(ILogger<HomeController> logger,IHomeService homeService)
        {
            _homeService = homeService;
            _logger = logger;
        }

        public async Task<ActionResult> Index()
        {
            try
            {
                //throw new Exception();
                var data = await _homeService.GetDashboardData();
               
                return View("LandingPage", data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"Error occured");

                return RedirectToAction("Error", "Home");
            }
        }

        public ActionResult Error()
        {
            return View();
        }



    }
}
