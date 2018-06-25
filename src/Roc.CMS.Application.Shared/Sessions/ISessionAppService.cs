using System.Threading.Tasks;
using Abp.Application.Services;
using Roc.CMS.Sessions.Dto;

namespace Roc.CMS.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();

        Task<UpdateUserSignInTokenOutput> UpdateUserSignInToken();
    }
}
