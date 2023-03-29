using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace WorkHiveServices.Interface
{
    public  interface IClientService
    {
        public Task<User> GetClientDetails(string userId);
        public Task<bool> UpdateClientDetails(User freelancer);
        public Task<List<Bid>> GetBids(string userId);
        public Task<bool> UpdateBidStatus(int bidId);


    }
}
