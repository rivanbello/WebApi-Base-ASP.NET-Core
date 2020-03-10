using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Segfy.Business.Interfaces.Arguments;
using Segfy.Business.Interfaces.Services;
using Segfy.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Segfy.Api.Controllers
{
    [Route("api/youtube")]

    public class YoutubeController : MainController
    {
        private readonly IYoutubeService _youtubeService;
        private readonly IMapper _mapper;

        public YoutubeController(INotifier notifier,
                                 IMapper mapper,
                                 IYoutubeService youtubeService) : base(notifier)
        {
            _youtubeService = youtubeService;
            _mapper = mapper;
        }

        // GET api/get-videos
        [HttpGet("get-videos/{query:string}")]
        public async Task<ActionResult<IEnumerable<Youtube>>> GetByQuery(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return BadRequest();
            }

            var result = _youtubeService.Search(query);

            return Ok(result);
        }
    }
}
