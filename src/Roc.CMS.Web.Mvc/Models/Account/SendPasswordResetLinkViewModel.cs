using System.ComponentModel.DataAnnotations;

namespace Roc.CMS.Web.Models.Account
{
    public class SendPasswordResetLinkViewModel
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}