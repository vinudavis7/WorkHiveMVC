using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Contract
    {
        public int ContractId { get; set; }
        public int JobId { get; set; }
        public int ClientId { get; set; }
        public int FreelancerId { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime DateCreated { get; set; }
        public string PaymentTerms { get; set; }
        public Job Job { get; set; }
        public Client Client { get; set; }
        public Freelancer Freelancer { get; set; }

    }
}
