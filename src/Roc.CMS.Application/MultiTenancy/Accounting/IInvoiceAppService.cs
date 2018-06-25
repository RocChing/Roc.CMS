using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Roc.CMS.MultiTenancy.Accounting.Dto;

namespace Roc.CMS.MultiTenancy.Accounting
{
    public interface IInvoiceAppService
    {
        Task<InvoiceDto> GetInvoiceInfo(EntityDto<long> input);

        Task CreateInvoice(CreateInvoiceDto input);
    }
}
