using Segfy.Youtube.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Segfy.Youtube.Interfaces
{
    public interface IYoutubeService : IDisposable
    {
        Task<IEnumerable<YoutubeModel>> Search(YoutubeResponse youtubeResponse);
    }
}
