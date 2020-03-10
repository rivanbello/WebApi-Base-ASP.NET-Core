﻿using Segfy.Core.Business.Models.Base;
using System;

namespace Segfy.Core.Business.Models
{
    public class Youtube : Entity
    {
        public Youtube(Item item)
        {
            Title = item.snippet.title;
            Description = item.snippet.description;
            ThumbnailUrl = item.snippet.thumbnails.medium.url;
            IsChannel = item.kind == "youtube#channel";
            ChannelName = item.snippet.channelTitle;
            PublishedAt = item.snippet.publishedAt;
        }

        public string Title{ get; set; }

        public string Description { get; set; }

        public string ThumbnailUrl { get; set; }

        public bool IsChannel { get; set; }

        public string ChannelName { get; set; }

        public DateTime PublishedAt { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
