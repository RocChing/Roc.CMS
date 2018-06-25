using Roc.CMS.Editions;

namespace Roc.CMS.MultiTenancy.Payments.Dto
{
    public class CreatePaymentDto
    {
        public int EditionId { get; set; }

        public EditionPaymentType EditionPaymentType { get; set; }

        public PaymentPeriodType? PaymentPeriodType { get; set; }

        public SubscriptionPaymentGatewayType SubscriptionPaymentGatewayType { get; set; }
    }
}
