﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using WorkHiveServices;
using WorkHiveServices.Interface;
using Microsoft.AspNetCore.Http;
using Models.ViewModel;

namespace WorkHiveMVC.Controllers
{
    public class FreelancerController : Controller
    {
        string userId = "";
        private readonly IFreelancerService _freelancerService;
        private readonly IUserService _userservice;
        private readonly IReviewService _reviewService;

        public FreelancerController(IFreelancerService freelancerService, IUserService userService, IHttpContextAccessor httpContextAccessor, IReviewService reviewService)
        {
            _freelancerService = freelancerService;
            _userservice = userService;
            userId = httpContextAccessor.HttpContext.Session.GetString("loggedInUserId");
            _reviewService = reviewService;
        }

        public async Task<ActionResult> FreelancersMapView()
        {
            return View();
        }
        public async Task<ActionResult> Profile(string? userId)
        {
            try
            {
                if (string.IsNullOrEmpty(userId))
                    userId = HttpContext.Session.GetString("loggedInUserId");
                var details = await _freelancerService.GetFreelancerDetails(userId);
                return View(details);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }
        public  async Task<bool> SaveReview([FromBody]ReviewRequest review)
        {
            review.ClientId = userId;
            var result =await _reviewService.CreateReview(review);
            return result;
        }
        public async Task<List<object>> GetFreelancers()
        {
            List<object> list = new List<object>();

            try
            {
                var usersList = await _userservice.GetUsersByRole("Freelancer");
                foreach (var user in usersList)
                {
                    string cordinates = user.Profile != null ? user.Profile.LocationCordinates : "";
                    if (!string.IsNullOrEmpty(cordinates))
                    {
                        string[] location = cordinates.Split(",");
                        object o = new
                        {
                            id = user.Id,
                            name = user.UserName,
                            cordinates = cordinates,
                            lat = Convert.ToDecimal(location[0]),
                            lng = Convert.ToDecimal(location[1])
                        };
                        list.Add(o);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
        [HttpGet]
        public async Task<ActionResult> EditProfile()
        {
            try
            {
                var profile = await _freelancerService.GetFreelancerDetails(userId);
                return View(profile);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Edit(User user, IFormFile fileUpload)
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
                var details = await _freelancerService.UpdateProfile(user);
                return RedirectToAction("Profile");
            }
            catch (Exception ex)
            {
                return RedirectToAction("EditProfile");
            }
        }

        public async Task<ActionResult> ViewProposals()
        {
            try
            {
                var details = await _freelancerService.GetBids(userId);
                return View(details);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

    }
}
