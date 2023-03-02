using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace WorkHiveServices.Interface
{
    public  interface IJobService
    {
        public Task<List<Jobs>> GetJobs();
    }
}
