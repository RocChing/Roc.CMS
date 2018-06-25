using System.ComponentModel.DataAnnotations;

namespace Roc.CMS.Authorization.Accounts.Dto
{
    public class SendEmailActivationLinkInput
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}