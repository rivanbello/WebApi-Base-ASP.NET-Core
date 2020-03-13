﻿using Segfy.Core.Application.Services.Base;
using Segfy.Core.Business.Interfaces.Arguments;
using Segfy.Youtube.Models;
using Segfy.Youtube.Interfaces;
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

        public async Task<IEnumerable<YoutubeModel>> Search(YoutubeResponse youtubeResponse)
        {

            return null;
        }

        public void Dispose()
        {
            _youtubeRepository?.Dispose();
        }
    }
}