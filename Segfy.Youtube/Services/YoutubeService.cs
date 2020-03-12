using Segfy.Core.Application.Services.Base;
using Segfy.Core.Business.Interfaces.Arguments;
using Segfy.Core.Business.Interfaces.Repositories;
using Segfy.Youtube.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Segfy.Youtube.Services
{
    public class YoutubeService : Service, IYoutubeService
    {
        private readonly IYoutubeRepository _youtubeRepository;

        public YoutubeService(INotifier notifier,
                              IYoutubeRepository youtubeRepository) : base(notifier)
        {
            _youtubeRepository = youtubeRepository;
        } 

        public async Task<IEnumerable<YoutubeModel>> Search(string query)
        {

            return null;
        }

        public void Dispose()
        {
            _youtubeRepository?.Dispose();
        }
    }
}
