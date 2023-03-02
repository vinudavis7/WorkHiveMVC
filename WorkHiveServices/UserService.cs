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
    public class UserService:IUserService
    {
        public async Task<List<Users>> GetUsers()
        {
            List<Users> usersList=new List<Users>();
            try
            {
                usersList = await ApiHelper.GetAsync<List<Users>>("api/User");
               // usersList = JsonConvert.DeserializeObject<List<User>>(response.res .ToString());
                //using (var client = new HttpClient())
                //{
                //    client.BaseAddress = new Uri("https://localhost:7223/");
                //    client.DefaultRequestHeaders.Accept.Clear();
                //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //    // HTTP GET
                //    HttpResponseMessage response = await client.GetAsync("api/User/");
                //    if (response.IsSuccessStatusCode)
                //    {
                //        return usersList = await response.Content.ReadFromJsonAsync<List<User>>();
                //     //  return usersList = JsonConvert.SerializeObject<List<User>>(users);

                //    }
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return usersList;
        }
    }
}
