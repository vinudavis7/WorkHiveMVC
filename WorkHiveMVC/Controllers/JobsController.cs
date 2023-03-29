using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Models;
using Models.ViewModel;
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
       
        public async Task<IActionResult> JobSearch(string? searchLocation, string? searchTitle)
        {
           //var jobsList= await _jobService.GetJobs(searchLocation, searchTitle,"","");
            ViewBag.SearchTitle = searchTitle;
            ViewBag.SearchLocation = searchLocation;
            ViewBag.JobType = "";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Search([FromBody] VMJobSearchParams searchParams)
        {
            string jobType = "";
            var jobsList = await _jobService.GetJobs(searchParams);
            ViewBag.SearchTitle = searchParams.SearchTitle;
            ViewBag.SearchLocation = searchParams.SearchLocation;
            ViewBag.JobType = jobType;
            return PartialView("_PartialViewJobCard", jobsList);
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
        public async Task<bool> SaveBid([FromBody] BidRequest bid)
        {
            try
            {

                string userId =HttpContext.Session.GetString("loggedInUserId");
                bid.UserId = userId;
                var result = await _jobService.SaveBid(bid);
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
