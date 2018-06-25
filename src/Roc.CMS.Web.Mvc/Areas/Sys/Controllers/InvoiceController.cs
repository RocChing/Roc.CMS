using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using Roc.CMS.MultiTenancy.Accounting;
using Roc.CMS.Web.Areas.Sys.Models.Accounting;
using Roc.CMS.Web.Controllers;

namespace Roc.CMS.Web.Areas.Sys.Controllers
{
    [Area("Sys")]
    public class InvoiceController : AbpZeroTemplateControllerBase
    {
        private readonly IInvoiceAppService _invoiceAppService;

        public InvoiceController(IInvoiceAppService invoiceAppService)
        {
            _invoiceAppService = invoiceAppService;
        }


        [HttpGet]
        public async Task<ActionResult> Index(long paymentId)
        {
            var invoice = await _invoiceAppService.GetInvoiceInfo(new EntityDto<long>(paymentId));
            var model = new InvoiceViewModel
            {
                Invoice = invoice
            };

            return View(model);
        }
    }
}