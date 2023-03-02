using Microsoft.AspNetCore.Mvc;
using WorkHiveServices;
using WorkHiveServices.Interface;

namespace WorkHiveMVC.Controllers
{
    public class JobsController : Controller
    {
        private readonly IJobService _jobService;
        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }
        public IActionResult Index()
        {
            return View("LandingPage");
        }
        public async Task<IActionResult> JobSearch()
        {
           var jobsList= await _jobService.GetJobs();
            return View(jobsList);
        }
        public IActionResult JobDetails()
        {
            return View();
        }
        
    }
}
