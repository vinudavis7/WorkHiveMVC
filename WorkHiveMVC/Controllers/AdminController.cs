using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Models.ViewModel;
using System.Drawing.Printing;
using WorkHiveServices;
using WorkHiveServices.Interface;
using X.PagedList;

namespace WorkHiveMVC.Controllers
{
    public class AdminController : Controller
    {
        // private readonly IAdminService _adminService;
        private readonly IJobService _jobService;
        private readonly IUserService _userservice;
        private readonly IHomeService _homeService;
        private readonly ICategoryService _categoryService;

        int pageSize = 10;
        int pageNumber = 1;

        public AdminController(IJobService jobService, IUserService userService, IHomeService homeService, ICategoryService categoryService)
        {
            _jobService = jobService;
            _userservice = userService;
            _homeService = homeService;
            _categoryService = categoryService;
        }
        public async Task<ActionResult> Dashboard()
        {
            try
            {
                IDictionary<string, int> data = await _homeService.GetDashboardSummary();
                ViewBag.data = data;
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }
        public async Task<ActionResult> Users(int? page)
        {
            try
            {
                pageNumber = (page ?? 1);
                var usersList = await _userservice.GetUsers();
                return View(usersList.ToPagedList(pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public async Task<ActionResult> Jobs(int? page)
        {
            try
            {
                JobSearchParams searchOptions = new JobSearchParams();
                pageNumber = (page ?? 1);
                var jobs = await _jobService.GetJobs(searchOptions);
                return View(jobs.ToPagedList(pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }


        public async Task<ActionResult> Category(int? page)
        {
            try
            {
                pageNumber = (page ?? 1);
                var categoryList = await _categoryService.GetCategory();
                return View(categoryList.ToPagedList(pageNumber, pageSize));
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }

        }


        [HttpPost]
        public async Task<bool> CreateCategory(string categoryName)
        {
            try
            {
                var result = await _categoryService.CreateCategory(categoryName);
                return result;
            }
            catch
            {
                return false;
            }
        }
    }
}
