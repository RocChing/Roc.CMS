using Newtonsoft.Json;

namespace Roc.CMS.MultiTenancy.Payments.Paypal
{
    public class PayPalAccessTokenResult
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    }
}