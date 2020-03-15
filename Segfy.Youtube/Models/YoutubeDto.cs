using System.Collections.Generic;
using System.Linq;

namespace Segfy.Youtube.Models
{
    public class YoutubeDto
    {
        public YoutubeDto()
        {
            Items = new List<YoutubeModel>();
        }

        public List<YoutubeModel> Items { get; set; }

        public string NextPageToken { get; set; }
    }
}
