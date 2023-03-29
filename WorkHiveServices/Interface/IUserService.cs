﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.ViewModel;

namespace WorkHiveServices.Interface
{
    public  interface IUserService
    {
        public Task<List<User>> GetUsers();
        public Task<User> GetUserDetails(string userId);
        public Task<bool> Register(RegisterRequest user);
        public Task<bool> UpdateUser(User user);
        public  Task<LoginResponse> Login(string username, string password);
    }
}
