﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class LoginResponse
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
