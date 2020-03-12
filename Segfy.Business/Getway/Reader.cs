using Newtonsoft.Json;
using Segfy.Core.Business.Models.Base;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Segfy.Core.Getway
{
    public class Reader :IReader
    {
        public async Task<T> Get<T>(string URI, ReaderParams readerParams) where T : object
        {
            try
            {
                using (var client = new HttpClient())
                {
                    if (readerParams.Token != null)
                    {
                        client.DefaultRequestHeaders.Add("Authorization", "Basic" + readerParams.Token);
                    }

                    using (var response = await client.GetAsync(URI))
                    {
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();

                        var res = JsonConvert.DeserializeObject<T>(responseBody);
                        return res;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
