using Helper;
using Models;
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
        public async Task<List<Job>> GetJobs()
        {
            List<Job> usersList=new List<Job>();
            try
            {
                usersList = await ApiHelper.GetAsync<List<Job>>("api/Jobs");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return usersList;
        }
        public async Task<Job> GetJobDetails(int jobId)
        {
            Job jobDetails = new Job();
            try
            {
                jobDetails = await ApiHelper.GetAsync<Job>("api/Jobs/"+jobId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return jobDetails;
        }

        public async Task<bool> SaveProposal(Proposal proposal)
        {
            Job jobDetails = new Job();
            try
            {
                var result = await ApiHelper.PostAsync<Job>("api/Proposals", proposal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
    }
}
