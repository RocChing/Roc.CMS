using Abp.MultiTenancy;
using Roc.CMS.Url;

namespace Roc.CMS.Web.Url
{
    public class MvcAppUrlService : AppUrlServiceBase
    {
        public override string EmailActivationRoute => "Account/EmailConfirmation";

        public override string PasswordResetRoute => "Account/ResetPassword";

        public MvcAppUrlService(
                IWebUrlService webUrlService,
                ITenantCache tenantCache
            ) : base(
                webUrlService,
                tenantCache
            )
        {

        }
    }
}