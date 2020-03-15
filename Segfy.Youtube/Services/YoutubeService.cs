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
            };

            foreach (var item in youtubeResponse.items)
            {
                var ytModel = new YoutubeModel();

                ytModel.Title = item.snippet.title;
                ytModel.Description = item.snippet.description;
                ytModel.PublishedAt = item.snippet.publishedAt;
                ytModel.IsChannel = false;
                ytModel.ChannelName = item.snippet.channelTitle;
                ytModel.ThumbnailUrl = item.snippet.thumbnails.medium.url;

                if (item.id.kind == "youtube#channel")
                {
                    ytModel.IsChannel = true;
                    ytModel.youtubeId = item.id.channelId;
                }
                else if(item.id.kind == "youtube#video")
                {
                    ytModel.youtubeId = item.id.videoId;
                }
                else
                {
                    ytModel.youtubeId = item.id.playlistId;
                }

                if (_youtubeRepository.Exists(x => x.youtubeId == ytModel.youtubeId))
                {
                    var res = _youtubeRepository.ListBy(x => x.youtubeId == ytModel.youtubeId).Result.FirstOrDefault();
                    ytModel.Id = res.Id;
                    await _youtubeRepository.Update(ytModel);
                }
                else
                {
                    await _youtubeRepository.Create(ytModel);
                }

                youtubeDto.Items.Add(ytModel);
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
