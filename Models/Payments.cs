using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Payments
    {
        public int paymentId { get; set; }

        public int contractId { get; set; }
        public int amount { get; set; }

        public string paymentMethod { get; set; }

        public DateTime paymentDate { get; set; }
    }
}
