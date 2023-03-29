using Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace Helper
{
    public static class ApiHelper
    {

        #region Generic Type Response

        public static async Task<T> GetAsync<T>(string endpoint)
        {
            try
            {


                T data;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7223/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // HTTP GET
                    HttpResponseMessage response = await client.GetAsync(endpoint);
                    if (response.IsSuccessStatusCode)
                    {
                        string d = await response.Content.ReadAsStringAsync();
                        if (d != null)
                        {
                            data = JsonConvert.DeserializeObject<T>(d);
                            return (T)data;
                        }

                    }
                }
            }catch(Exception ex)
            {
                throw ex;
            }

        Object o = new Object();
            return (T)o;
        }
        public static async Task<T> SendAsync<T>(string endpoint,object param)
        {
            T data;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7223/");
                client.DefaultRequestHeaders.Accept.Clear();
               // client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(client.BaseAddress+endpoint),
                    Content = new StringContent(JsonConvert.SerializeObject(param), Encoding.UTF8, "application/json"),

                };
                HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    string d = await response.Content.ReadAsStringAsync();
                    if (d != null)
                    {
                        data = JsonConvert.DeserializeObject<T>(d);
                        return (T)data;
                    }

                }
            }

            Object o = new Object();
            return (T)o;
        }

        //public static async Task<T> GetAsync(string url)
        //{

        //    T data;
        //    try
        //    {
        //        using (var client = new HttpClient())
        //        {
        //            client.BaseAddress = new Uri("https://localhost:7223/");
        //            client.DefaultRequestHeaders.Accept.Clear();
        //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //            // HTTP GET
        //            HttpResponseMessage response = await client.GetAsync("api/products/1");
        //            if (response.IsSuccessStatusCode)
        //            {
        //                string d = await response.Content.ReadAsStringAsync();
        //                if (d != null)
        //                {
        //                    data = JsonConvert.DeserializeObject<T>(d);
        //                    return (T)data;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Object ob = new Object();
        //        return (T)ob;
        //    }
        //    Object o = new Object();
        //    return (T)o;
        //}



        public static async Task<bool> PostRequestAsync<T>(string endpoint,T value)
        {

            using (var client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7223/api/");
                var cc=await client.PostAsJsonAsync("Freelancer", value);
                //var res= await client.PostAsJsonAsync<T>(endpoint, value);
                return true;
            }
        }
        public static async Task<T> PostAsync<T>(string url, object param)
        {
            try
            {
                T data;
                var client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:7223/");
                string jsonData = JsonConvert.SerializeObject(param);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                using (HttpResponseMessage response = await client.PostAsync(url, content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string d = await response.Content.ReadAsStringAsync();
                        if (d != null)
                        {
                            data = JsonConvert.DeserializeObject<T>(d);
                            return (T)data;
                        }

                    }
                }



                // T data;
                // var httpClient = new HttpClient();
                // var client = new HttpClient();
                // client.BaseAddress = new Uri("https://localhost:7223/");
                // client.DefaultRequestHeaders.Accept.Clear();
                // client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // var json = JsonConvert.SerializeObject(httpClient);
                // HttpContent contentPost = new StringContent(JsonConvert.SerializeObject(param), Encoding.UTF8, "application/json");

                //  StringContent content = new StringContent(JsonConvert.SerializeObject(param), Encoding.UTF8, "application/json");
                // //var bodyJson = JsonSerializer.Serialize(param);
                //// var stringContent = new StringContent(bodyJson, Encoding.UTF8, "application/json");


                // // var result = postTask.Result;
                // var response = await client.PostAsJsonAsync(url, param);
                // // using (HttpResponseMessage response = await client.PostAsync(url, content))
                // //using (HttpContent content = response.Content)
                // //{
                // //    string d = await content.ReadAsStringAsync();
                // //    if (d != null)
                // //    {
                // //        data = JsonConvert.DeserializeObject<T>(d);
                // //        return (T)data;
                // //    }
                // //}
                // // Object o = new Object();
                // //return (T)o;


                //return false;
                Object o = new Object();
                return (T)o;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static async Task<T> PutAsync<T>(string url, object param)
        {
            T data;
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7223/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpContent contentPost = new StringContent(JsonConvert.SerializeObject(param), Encoding.UTF8, "application/json");

            using (HttpResponseMessage response = await client.PutAsync(url, contentPost))
            using (HttpContent content = response.Content)
            {
                string d = await content.ReadAsStringAsync();
                if (d != null)
                {
                    data = JsonConvert.DeserializeObject<T>(d);
                    return (T)data;
                }
            }
            Object o = new Object();
            return (T)o;
        }

        //public async Task<T> DeleteAsync<T>(string url)
        //{
        //    T newT;
        //    var httpClient = _httpClientFactory.CreateClient();

        //    using (HttpResponseMessage response = await httpClient.DeleteAsync(url))
        //    using (HttpContent content = response.Content)
        //    {
        //        string data = await content.ReadAsStringAsync();
        //        if (data != null)
        //        {
        //            newT = JsonConvert.DeserializeObject<T>(data);
        //            return newT;
        //        }
        //    }
        //    Object o = new Object();
        //    return (T)o;
        //}

        //public static async Task<T> PutAsync<T>(string endpoint)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("http://localhost:64189/api/student");

        //        //HTTP POST
        //        var putTask = client.PutAsJsonAsync<T>(d);
        //        putTask.Wait();

        //        var result = putTask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {

        //            return RedirectToAction("Index");
        //        }
        //    }

            #endregion
        //}
    }
}
