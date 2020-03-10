using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Segfy.Core.Business.Interfaces.Arguments;
using Segfy.Core.Business.Interfaces.Repositories;
using Segfy.Core.Business.Interfaces.Services;
using Segfy.Core.Business.Models;
using Segfy.Core.Application.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Segfy.Core.Application
{
    public class YoutubeService : Service, IYoutubeService
    {
        private readonly IConfiguration _config;
        private readonly IYoutubeRepository _youtubeRepository;

        public YoutubeService(INotifier notifier, 
                              IConfiguration config, 
                              IYoutubeRepository youtubeRepository) : base(notifier)
        {
            _config = config;
            _youtubeRepository = youtubeRepository;
        } 

        public async Task<IEnumerable<Youtube>> Search(string query)
        {
            var apiResponse = new YoutubeResponse();

            var youtubeConfigs = _config.GetSection("YoutubeConfigs");
            var baseUrl = youtubeConfigs["baseUrl"].ToString();
            var key = youtubeConfigs["key"].ToString();


            var url = string.Format("{0}search?part=snippet&q={1}&key={2}", baseUrl, query, key);

            using (var client = new HttpClient())
            {
                var httpResponse = await client.GetAsync(url);

                var content = await httpResponse.Content.ReadAsStringAsync();
                apiResponse = JsonConvert.DeserializeObject<YoutubeResponse>(content);
            }

            var items = apiResponse.items.Select(x => new Youtube(x));

            foreach (var item in items)
            {
                if (_youtubeRepository.GetById(item.Id) != null)
                {
                    await _youtubeRepository.Update(item);
                }
                else
                {
                    await _youtubeRepository.Create(item);
                }
            }

            return items.ToList();
        }

        public void Dispose()
        {
            _youtubeRepository?.Dispose();
        }
    }
}
