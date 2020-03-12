using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Segfy.Core.Business.Interfaces.Arguments;
using Segfy.Core.Getway;
using Segfy.Youtube.Models;
using Segfy.Youtube.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Segfy.Api.Controllers
{
    [Route("api/youtube")]

    public class YoutubeController : MainController
    {
        private readonly IYoutubeService _youtubeService;
        private readonly IMapper _mapper;
        private readonly IReader _reader;
        private readonly IConfiguration _config;

        public YoutubeController(IYoutubeService youtubeService,
                                 IMapper mapper, IReader reader,
                                 IConfiguration config,
                                 INotifier notifier) : base(notifier)
        {
            _youtubeService = youtubeService;
            _mapper = mapper;
            _reader = reader;
            _config = config;
        }

        // GET api/get-videos
        [HttpGet("get-videos/{query:string}")]
        public async Task<ActionResult<IEnumerable<YoutubeModel>>> GetByQuery(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return BadRequest();
            }

            var youtubeConfigs = _config.GetSection("YoutubeConfigs");
            var baseUrl = youtubeConfigs["baseUrl"].ToString();
            var key = youtubeConfigs["key"].ToString();

            //var url = string.Format("{0}search?part=snippet&q={1}&key={2}", baseUrl, query, key);

            var readerParams = new ReaderParams
            {
                urlParams = new Dictionary<string, string>
                {
                    { "part", "snippet" },
                    { "q", query },
                    { "key", key }
                }
            };

            var res = await _reader.Get<YoutubeResponse>(baseUrl + "search?", readerParams);

            var result = _youtubeService.Search(res);

            return Ok(result);
        }
    }
}
