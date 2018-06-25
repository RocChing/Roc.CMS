using System.Threading.Tasks;
using Roc.CMS.Security.Recaptcha;

namespace Roc.CMS.Tests.Web
{
    public class FakeRecaptchaValidator : IRecaptchaValidator
    {
        public Task ValidateAsync(string captchaResponse)
        {
            return Task.CompletedTask;
        }
    }
}
