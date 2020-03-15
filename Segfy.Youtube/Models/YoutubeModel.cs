using Segfy.Core.Business.Models.Base;
using System;

namespace Segfy.Youtube.Models
{
    public class YoutubeModel : Entity
    {
        public string youtubeId { get; set; }

        public string Title{ get; set; }

        public string Description { get; set; }

        public string ThumbnailUrl { get; set; }

        public bool IsChannel { get; set; }

        public string ChannelName { get; set; }

        public DateTime PublishedAt { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
