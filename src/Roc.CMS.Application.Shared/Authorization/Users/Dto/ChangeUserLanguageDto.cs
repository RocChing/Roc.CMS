using System.ComponentModel.DataAnnotations;

namespace Roc.CMS.Authorization.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}
