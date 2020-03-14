using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Segfy.Core.Business.Interfaces.Arguments;
using Segfy.Core.Getway;
using Segfy.Youtube.Interfaces;
using Segfy.Youtube.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Segfy.Api.Controllers
{
    [Route("api/youtube")]

    public class YoutubeController : MainController
    {
        private readonly IYoutubeService _youtubeService;
        

        public YoutubeController(IYoutubeService youtubeService,
                                 INotifier notifier) : base(notifier)
        {
            _youtubeService = youtubeService;
        }

        // GET api/search
        [HttpGet("search/{query}")]
        public async Task<ActionResult<YoutubeDto>> GetByQuery(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return BadRequest();
            }

            var result = _youtubeService.Search(query);

            return Ok(result);
        }

        // GET api/get-items
        [HttpGet("get-items")]
        public async Task<ActionResult<YoutubeDto>> GetItems()
        {
            var res = _youtubeService.GetItems().Result.ToList();

            //var result = new YoutubeDto
            //{
            //    Items = res.Select(x => )
            //};

            return Ok(res);
        }
    }
}
