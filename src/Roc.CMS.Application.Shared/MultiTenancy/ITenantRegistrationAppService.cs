using System.Threading.Tasks;
using Abp.Application.Services;
using Roc.CMS.Editions.Dto;
using Roc.CMS.MultiTenancy.Dto;

namespace Roc.CMS.MultiTenancy
{
    public interface ITenantRegistrationAppService: IApplicationService
    {
        Task<RegisterTenantOutput> RegisterTenant(RegisterTenantInput input);

        Task<EditionsSelectOutput> GetEditionsForSelect();

        Task<EditionSelectDto> GetEdition(int editionId);
    }
}