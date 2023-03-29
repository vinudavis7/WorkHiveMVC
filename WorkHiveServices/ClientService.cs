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
    public class ClientService : IClientService
    {
        public Task<User> GetClientDetails(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Bid>> GetBids(string userId)
        {
            List<Bid> result = new List<Bid>();
            try
            {
               var user = await ApiHelper.GetAsync<User>("api/Users/GetDetails/" + userId);
                foreach (var job in user.Jobs)
                {
                    var bids = job.Bids;
                    foreach (var bid in bids)
                    {
                        Bid b = bid;
                        result.Add(b);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public async Task<bool> UpdateBidStatus(int bidId)
        {
            bool result = false;
            try
            {
                result = await ApiHelper.PostAsync<bool>("api/Bids/UpdateBidStatus/", bidId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }



        public Task<bool> UpdateClientDetails(User freelancer)
        {
            throw new NotImplementedException();
        }
    }
}
