using Roc.CMS.Configuration.Dto;

namespace Roc.CMS.Web.Areas.AppAreaName.Models.UiCustomization
{
    public class UiCustomizationViewModel
    {
        public UiCustomizationSettingsEditDto Settings { get; set; }

        public bool HasUiCustomizationPagePermission { get; set; }
    }
}
