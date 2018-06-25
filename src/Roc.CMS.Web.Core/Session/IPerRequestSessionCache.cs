using System.Threading.Tasks;
using Roc.CMS.Sessions.Dto;

namespace Roc.CMS.Web.Session
{
    public interface IPerRequestSessionCache
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformationsAsync();
    }
}
