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
        public Task<List<Job>> GetJobs();
        public Task<Job> GetJobDetails(int jobId);
        public  Task<bool> SaveProposal(Proposal proposal);
    }
}
