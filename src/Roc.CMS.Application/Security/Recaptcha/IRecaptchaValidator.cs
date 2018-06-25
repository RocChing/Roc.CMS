using System.Threading.Tasks;

namespace Roc.CMS.Security.Recaptcha
{
    public interface IRecaptchaValidator
    {
        Task ValidateAsync(string captchaResponse);
    }
}