using Segfy.Core.Business.Interfaces.Repositories;
using Segfy.Core.Business.Models;
using Segfy.Data.Persistence.Repository.Base;

namespace Segfy.Data.Persistence.Repository
{
    public class YoutubeRepository : Repository<Youtube>, IYoutubeRepository
    {
        public YoutubeRepository(SegfyContext context) : base(context)
        {
        }
    }
}
