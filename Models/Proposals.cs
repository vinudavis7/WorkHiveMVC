using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Proposals
    {
        public int proposalId { get; set; }

        public int jobId { get; set; }

        public int freelancerId { get; set; }

        public string proposalText { get; set; }

        public string proposalAttachment { get; set; }

        public DateTime DateSubmitted { get; set; }



    }
}
