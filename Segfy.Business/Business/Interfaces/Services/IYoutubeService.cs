using Segfy.Core.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Segfy.Core.Business.Interfaces.Services
{
    public interface IYoutubeService : IDisposable
    {
        Task<IEnumerable<Youtube>> Search(string query);
    }
}
