using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Review
    {
        public int ReviewId { get; set; }

        public int ClientId { get; set; }
        public int FreelancerId { get; set; }

        public string description { get; set; }
        public string Rating { get; set; }

        public DateTime DateCreated { get; set; }
        public Client Client { get; set; }
        public Freelancer Freelancer { get; set; }
    }
}
