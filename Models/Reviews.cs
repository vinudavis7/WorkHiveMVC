using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Reviews
    {
        public int reviewId { get; set; }
        public int clientId { get; set; }
        public int freelancerId { get; set; }

        public string review { get; set; }
        public DateTime DateCreated { get; set; }

    }
}
