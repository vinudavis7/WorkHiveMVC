using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using System.Data;
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
            var c = HttpContext.Session.GetString("loggedInUserId");
            return View("LandingPage");
        }
        public async Task<IActionResult> JobSearch()
        {
           var jobsList= await _jobService.GetJobs();
            return View(jobsList);
        }
        public async Task<IActionResult> JobDetails(int jobId)
        {
            var jobDetails = await _jobService.GetJobDetails(jobId);

            return View(jobDetails);
        }

        public async Task<IActionResult> CreateJob()
        {
            return View();
        }
        [HttpPost]
        public async Task<bool> SaveProposal([FromBody]  Proposal proposal)
        {
            try
            {

                int userId =Convert.ToInt32( HttpContext.Session.GetString("loggedInUserId"));
                proposal.FreelancerId = userId;
                var result = await _jobService.SaveProposal(proposal);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [NonAction]
        public SelectList ToSelectList(DataTable table, string valueField, string textField)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(new SelectListItem()
                {
                    Text = row[textField].ToString(),
                    Value = row[valueField].ToString()
                });
            }

            return new SelectList(list, "Value", "Text");
        }

    }
}
