using Microsoft.AspNetCore.Mvc;

namespace WorkHiveMVC.Controllers
{
    public class JobsController : Controller
    {

        public IActionResult Index()
        {
            return View("LandingPage");
        }
        public IActionResult JobSearch()
        {
            return View();
        }
    }
}
