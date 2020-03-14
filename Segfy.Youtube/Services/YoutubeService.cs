using Segfy.Core.Application.Services.Base;
using Segfy.Core.Business.Interfaces.Arguments;
using Segfy.Youtube.Models;
using Segfy.Youtube.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Segfy.Core.Getway;
using System.Linq;

namespace Segfy.Youtube.Services
{
    public class YoutubeService : Service, IYoutubeService
    {
        private readonly IYoutubeRepository _youtubeRepository;
        private readonly IConfiguration _config;
        private readonly IReader _reader;

        public YoutubeService(IConfiguration config,
                              IYoutubeRepository youtubeRepository,
                              IReader reader,
                              INotifier notifier) : base(notifier)
        {
            _config = config;
            _youtubeRepository = youtubeRepository;
            _reader = reader;
        }

        public async Task<YoutubeDto> Search(string query)
        {
            var youtubeConfigs = _config.GetSection("YoutubeConfigs");
            var baseUrl = youtubeConfigs["baseUrl"].ToString();
            var key = youtubeConfigs["key"].ToString();

            var readerParams = new ReaderParams
            {
                urlParams = new Dictionary<string, string>
                {
                    { "part", "snippet" },
                    { "q", query },
                    { "key", key }
                }
            };

            var youtubeResponse = await _reader.Get<YoutubeResponse>(baseUrl + "search?", readerParams);

            var youtubeDto = new YoutubeDto
            {
                NextPageToken = youtubeResponse.nextPageToken,
                Items = youtubeResponse.items.Select(x => new YoutubeModel(x))
            };

            foreach (var item in youtubeDto.Items)
            {
                if (_youtubeRepository.Exists(x => x.youtubeId == item.youtubeId))
                {
                    await _youtubeRepository.Update(item);
                }
                else
                {
                    await _youtubeRepository.Create(item);
                }
            }

            return youtubeDto;
        }

        public void Dispose()
        {
            _youtubeRepository?.Dispose();
        }

        public Task<IEnumerable<YoutubeModel>> GetItems()
        {
            var result = _youtubeRepository.List();

            return result;
        }
    }
}
