using System.Collections.Generic;
using System.Linq;

namespace Segfy.Youtube.Models
{
    public class YoutubeDto
    {
        public YoutubeDto()
        {
        }

        public IEnumerable<YoutubeModel> Items { get; set; }

        public string NextPageToken { get; set; }
    }
}
