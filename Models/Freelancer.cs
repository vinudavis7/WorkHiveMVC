﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Freelancer:User
    {
        public string Designation { get; set; }

        public string Description { get; set; }

        public string Portfolio { get; set; }

        public string Experience { get; set; }

        public double HourlyRate { get; set; }

        public string Skills { get; set; }
    }
}
