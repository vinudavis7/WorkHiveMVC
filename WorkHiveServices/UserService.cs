﻿using Helper;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WorkHiveServices.Interface;

namespace WorkHiveServices
{
    public class UserService:IUserservice
    {
        public async Task<List<User>> GetUsers()
        {
            List<User> usersList=new List<User>();
            try
            {
                usersList = await ApiHelper.GetAsync<List<User>>("api/Users");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return usersList;
        }

        public async Task<bool> Register(User user)
        {
            try
            {
                var res = await ApiHelper.PostAsync<bool>("api/Users", user);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<User> GetUserDetails(string username,string password)
        {
            try
            {
                var res = await ApiHelper.GetAsync<User>("api/Users/GetUserDetails?username="+ username+ "&password="+password);

                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
