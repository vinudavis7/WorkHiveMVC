using Microsoft.AspNetCore.Mvc;
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


        public ClientController(IClientService clientService, IJobService jobService, IUserService userService)
        {
            _clientService = clientService;
            _jobService = jobService;
            _userService = userService;
        }
        public async Task<ActionResult> Bids()
        {
            string userId = HttpContext.Session.GetString("loggedInUserId");

            var details = await _clientService.GetBids(userId);
            return View(details);
        }
        public async Task<ActionResult> MyJobs()
        {
            string userId = HttpContext.Session.GetString("loggedInUserId");
            VMJobSearchParams param = new VMJobSearchParams();
            param.ClientID = userId;
            var jobsList = await _jobService.GetJobs(param);

            return View(jobsList);
        }
        public async Task<ActionResult> EditProfile()
        {
            string userId = HttpContext.Session.GetString("loggedInUserId");

            var user = await _userService.GetUserDetails(userId);

            return View(user);
        }
        [HttpPost]
        public async Task<ActionResult> EditProfile(User user)
        {
            try
            {

                var details = await _userService.UpdateUser(user);
                return RedirectToAction("EditProfile");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public async Task<bool> UpdateBidStatus(int bidId)
        {

            var jobsList = await _clientService.UpdateBidStatus(bidId);

            return true;
        }

    }
}
