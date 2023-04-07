using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.ViewModel;

namespace WorkHiveServices.Interface
{
    public  interface IJobService
    {
        public Task<List<Job>> GetJobs(JobSearchParams searchParams);
        public Task<Job> GetJobDetails(int jobId);
        public Task<Job> CreateJob(JobRequest job);
        public  Task<bool> SaveBid(BidRequest bid);
    }
}
