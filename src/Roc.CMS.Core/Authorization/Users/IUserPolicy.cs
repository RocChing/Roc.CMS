using System.Threading.Tasks;
using Abp.Domain.Policies;

namespace Roc.CMS.Authorization.Users
{
    public interface IUserPolicy : IPolicy
    {
        Task CheckMaxUserCountAsync(int tenantId);
    }
}
