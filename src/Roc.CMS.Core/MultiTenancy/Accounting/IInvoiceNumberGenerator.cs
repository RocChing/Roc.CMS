using System.Threading.Tasks;
using Abp.Dependency;

namespace Roc.CMS.MultiTenancy.Accounting
{
    public interface IInvoiceNumberGenerator : ITransientDependency
    {
        Task<string> GetNewInvoiceNumber();
    }
}