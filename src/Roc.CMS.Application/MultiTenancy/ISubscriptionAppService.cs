using System.Threading.Tasks;
using Abp.Application.Services;

namespace Roc.CMS.MultiTenancy
{
    public interface ISubscriptionAppService : IApplicationService
    {
        Task UpgradeTenantToEquivalentEdition(int upgradeEditionId);
    }
}
