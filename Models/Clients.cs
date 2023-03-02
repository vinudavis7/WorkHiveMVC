using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Clients
    {
        public Users User { get; set; }

        public string CompanyName { get; set; }

        public string Website { get; set; }
    }
}
