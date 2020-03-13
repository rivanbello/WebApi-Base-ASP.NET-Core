using Segfy.Data.Persistence.Repository.Base;
using Segfy.Youtube.Models;
using Segfy.Youtube.Interfaces;

namespace Segfy.Data.Persistence.Repository
{
    public class YoutubeRepository : Repository<YoutubeModel>, IYoutubeRepository
    {
        public YoutubeRepository(SegfyContext context) : base(context)
        {
        }
    }
}
