using Abp.AutoMapper;
using Roc.CMS.Editions;
using Roc.CMS.MultiTenancy.Payments.Dto;

namespace Roc.CMS.Web.Areas.AppAreaName.Models.SubscriptionManagement
{
    [AutoMapTo(typeof(ExecutePaymentDto))]
    public class PaymentResultViewModel : SubscriptionPaymentDto
    {
        public EditionPaymentType EditionPaymentType { get; set; }
    }
}