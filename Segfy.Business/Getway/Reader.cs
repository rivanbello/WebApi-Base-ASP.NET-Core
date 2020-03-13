using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Segfy.Core.Getway
{
    public class Reader :IReader
    {
        public async Task<T> Get<T>(string URI, ReaderParams readerParams) where T : IResponse
        {
            try
            {
                //Preparar URL
                if (readerParams.urlParams.Count > 0)
                {
                    var count = 0;
                    URI = string.Format("{0}", URI);

                    foreach (var item in readerParams.urlParams)
                    {
                        if (count > 0)
                        {
                            URI += string.Format("&{0}={1}", item.Key, item.Value);
                        }
                        else
                        {
                            URI += string.Format("{0}={1}", item.Key, item.Value);
                        }

                        count++;
                    }
                }

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
