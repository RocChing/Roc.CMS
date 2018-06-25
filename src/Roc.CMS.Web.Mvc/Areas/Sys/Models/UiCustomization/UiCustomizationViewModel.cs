using Roc.CMS.Configuration.Dto;

namespace Roc.CMS.Web.Areas.Sys.Models.UiCustomization
{
    public class UiCustomizationViewModel
    {
        public UiCustomizationSettingsEditDto Settings { get; set; }

        public bool HasUiCustomizationPagePermission { get; set; }
    }
}
