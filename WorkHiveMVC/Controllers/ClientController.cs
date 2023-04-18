using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using Models.ViewModel;
using WorkHiveServices;
using WorkHiveServices.Interface;

namespace WorkHiveMVC.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        private readonly IJobService _jobService;
        private readonly IUserService _userService;
        private readonly ICategoryService _categoryService;


        public ClientController(IClientService clientService, IJobService jobService, IUserService userService, ICategoryService categoryService)
        {
            _clientService = clientService;
            _jobService = jobService;
            _userService = userService;
            _categoryService = categoryService;

        }
        public async Task<ActionResult> Bids()
        {
            try
            {
                string userId = HttpContext.Session.GetString("loggedInUserId");
                var details = await _clientService.GetBids(userId);
                return View(details);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }
        public async Task<ActionResult> MyJobs()
        {
            try
            {
                string userId = HttpContext.Session.GetString("loggedInUserId");
                JobSearchParams param = new JobSearchParams();
                param.ClientID = userId;
                var jobsList = await _jobService.GetJobs(param);
                return View(jobsList);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }
        public async Task<ActionResult> CreateJob()
        {
            try
            {
                List<Category> categoryList = await _categoryService.GetCategory();
                List<SelectListItem> items = new List<SelectListItem>();
                foreach (var cat in categoryList)
                {
                    items.Add(new SelectListItem { Value = cat.CategoryId.ToString(), Text = cat.CategoryName });
                }
                ViewBag.Category = items;
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }
        [HttpPost]
        public async Task<ActionResult> SaveJob(JobRequest job)
        {
            try
            {
                string userId = HttpContext.Session.GetString("loggedInUserId");
                job.UserId = userId;
                job.DatePosted = DateTime.Now;
                var user = await _jobService.CreateJob(job);
                return RedirectToAction("Myjobs");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public async Task<ActionResult> EditProfile()
        {
            try
            {
                string userId = HttpContext.Session.GetString("loggedInUserId");
                var user = await _userService.GetUserDetails(userId);
                return View(user);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }
        [HttpPost]
        public async Task<ActionResult> EditProfile(User user, IFormFile fileUpload)
        {
            try
            {
                if (fileUpload != null && fileUpload.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await fileUpload.CopyToAsync(memoryStream);
                        var imageData = memoryStream.ToArray();
                        var base64String = Convert.ToBase64String(imageData);
                        user.ProfileImage = base64String;
                    }
                }
                var details = await _userService.UpdateUser(user);
                return RedirectToAction("EditProfile");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public async Task<bool> UpdateBidStatus(int bidId)
        {
            var jobsList = await _clientService.UpdateBidStatus(bidId);
            return true;
        }

    }
}
