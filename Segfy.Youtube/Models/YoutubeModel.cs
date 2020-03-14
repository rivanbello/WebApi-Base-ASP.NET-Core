using Segfy.Core.Business.Models.Base;
using System;

namespace Segfy.Youtube.Models
{
    public class YoutubeModel : Entity
    {
        public YoutubeModel(Item item)
        {
            Title = item.snippet.title;
            Description = item.snippet.description;
            PublishedAt = item.snippet.publishedAt;
            IsChannel = item.id.kind == "youtube#channel";
            ChannelName = item.snippet.channelTitle;
            ThumbnailUrl = item.snippet.thumbnails.medium.url;

            if (item.id.kind == "youtube#channel")
            {
                youtubeId = item.id.channelId;
            }
            else
            {
                youtubeId = item.id.videoId;
            }
        }

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
