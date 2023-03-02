using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Contracts
    {
        public int contractId { get; set; }

        public int clientId { get; set; }

        public int jobId { get; set; }

        public int freelancerId { get; set; }

        public string paymentTerms { get; set; }

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
