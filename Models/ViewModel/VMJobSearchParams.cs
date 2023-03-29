using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class VMJobSearchParams
    {
        public string? SearchLocation { get; set; }
        public string? SearchTitle { get; set; }
        public string? SearchJobType { get; set; }
        public string? ClientID { get; set; }


    }
}
