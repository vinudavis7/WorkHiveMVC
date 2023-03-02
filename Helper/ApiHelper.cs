using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace Helper
{
    public static class ApiHelper
    {

        #region Generic Type Response
    
        public static async Task<T> GetAsync<T>(string endpoint)
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
        //public async Task<T> PostAsync<T>(string url, object param)
        //{
        //    try
        //    {
        //        T data;
        //        var httpClient = _httpClientFactory.CreateClient();
        //        var json = JsonConvert.SerializeObject(httpClient);
        //        HttpContent contentPost = new StringContent(JsonConvert.SerializeObject(param), Encoding.UTF8, "application/json");

        //        using (HttpResponseMessage response = await httpClient.PostAsync(url, contentPost))
        //        using (HttpContent content = response.Content)
        //        {
        //            string d = await content.ReadAsStringAsync();
        //            if (d != null)
        //            {
        //                data = JsonConvert.DeserializeObject<T>(d);
        //                return (T)data;
        //            }
        //        }
        //        Object o = new Object();
        //        return (T)o;
        //    }
        //    catch (Exception ex)
        //    {
        //        Object o = new Object();
        //        return (T)o;
        //    }

        //}
        //public async Task<T> PutAsync<T>(string url, object param)
        //{
        //    T data;
        //    var httpClient = _httpClientFactory.CreateClient();
        //    HttpContent contentPost = new StringContent(JsonConvert.SerializeObject(param), Encoding.UTF8, "application/json");

        //    using (HttpResponseMessage response = await httpClient.PutAsync(url, contentPost))
        //    using (HttpContent content = response.Content)
        //    {
        //        string d = await content.ReadAsStringAsync();
        //        if (d != null)
        //        {
        //            data = JsonConvert.DeserializeObject<T>(d);
        //            return (T)data;
        //        }
        //    }
        //    Object o = new Object();
        //    return (T)o;
        //}

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


        #endregion

    }
}