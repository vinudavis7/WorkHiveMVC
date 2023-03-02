using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Jobs
    {
        public int JobId { get; set; }
        public int CategoryId { get; set; }

        public Categories Category { get; set; }
        public int UserId { get; set; }
        public Users Client { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }

        public string Description { get; set; }
        public int Budget { get; set; }
        public string SkillTags { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime DatePosted { get; set; }

   

    

       


    }
}
