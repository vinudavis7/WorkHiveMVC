using Helper;
using Models;
using Models.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WorkHiveServices.Interface;

namespace WorkHiveServices
{
    public class JobService:IJobService
    {
        public async Task<List<Job>> GetJobs(VMJobSearchParams searchParams)
        {
            List<Job> jobList=new List<Job>();
            try
            {
                jobList = await ApiHelper.GetAsync<List<Job>>("api/Jobs?SearchLocation=" + searchParams.SearchLocation 
                    + "&SearchTitle=" + searchParams.SearchTitle + "&SearchJobType=" + searchParams.SearchJobType + "");

                //await ApiHelper.SendAsync<List<Job>>("api/Jobs", searchParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return jobList;
        }
        public async Task<Job> GetJobDetails(int jobId)
        {
            Job jobDetails = new Job();
            try
            {
                jobDetails = await ApiHelper.GetAsync<Job>("api/Jobs/GetDetails/" + jobId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return jobDetails;
        }

        public async Task<bool> SaveBid(BidRequest bid)
        {
            try
            {
                var result = await ApiHelper.PostAsync<bool>("api/Bids", bid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
    }
}
