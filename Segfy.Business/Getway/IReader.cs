using Segfy.Core.Business.Models.Base;
using System.Threading.Tasks;

namespace Segfy.Core.Getway
{
    public interface IReader
    {
        Task<T> Get<T>(string URI, ReaderParams reader) where T : ;
    }
}
