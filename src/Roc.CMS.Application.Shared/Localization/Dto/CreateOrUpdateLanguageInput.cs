using System.ComponentModel.DataAnnotations;

namespace Roc.CMS.Localization.Dto
{
    public class CreateOrUpdateLanguageInput
    {
        [Required]
        public ApplicationLanguageEditDto Language { get; set; }
    }
}