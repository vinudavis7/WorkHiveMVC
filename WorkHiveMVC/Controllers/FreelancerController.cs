using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using WorkHiveServices.Interface;

namespace WorkHiveMVC.Controllers
{
    public class FreelancerController : Controller
    {
        private readonly IFreelancerService _freelancerService;
        public FreelancerController(IFreelancerService freelancerService)
        {
            _freelancerService = freelancerService;
        }


        public async Task<ActionResult> Profile()
        {
            string userId = HttpContext.Session.GetString("loggedInUserId");

            var details = await _freelancerService.GetFreelancerDetails(userId);
            return View(details);
        }

        [HttpGet]
        public async Task<ActionResult> EditProfile()
        {
            string userId = HttpContext.Session.GetString("loggedInUserId");

            var details = await _freelancerService.GetFreelancerDetails(userId);
            return View(details);
        }

        // POST: FreelancerController/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(User user)
        {
            try
            {

                var details = await _freelancerService.UpdateProfile(user);
                return RedirectToAction("Profile");
            }
            catch (Exception ex)
            {
                return View();
            }
        }


        public async Task<ActionResult> ViewProposals()
        {
            string userId = HttpContext.Session.GetString("loggedInUserId");

            var details = await _freelancerService.GetBids(userId);
            return View(details);
        }

    }
}
