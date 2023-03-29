﻿using System;
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
        public Task<List<Job>> GetJobs(VMJobSearchParams searchParams);
        public Task<Job> GetJobDetails(int jobId);
        public  Task<bool> SaveBid(BidRequest bid);
    }
}
