using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

            
            public AdminController(IJobService jobService, IUserService userService, IHomeService homeService)
        {
            _jobService = jobService;
            _userservice = userService;
                _homeService = homeService;
            }
        // GET: AdminController
        public async Task<ActionResult> Dashboard()
        {
            var data = await _homeService.GetDashboardSummary();
            ViewBag.data = data;
            return View();
        }

        // GET: AdminController/Details/5
        public async Task<ActionResult> Users(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var usersList = await _userservice.GetUsers();
            return View(usersList.ToPagedList(pageNumber, pageSize));
        }

        // GET: AdminController/Create
        public async Task<ActionResult> Jobs(int? page)
        {
            VMJobSearchParams obj= new VMJobSearchParams();
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var jobs = await _jobService.GetJobs(obj);
            return View(jobs.ToPagedList(pageNumber, pageSize));
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
