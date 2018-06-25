using System.Collections.Generic;
using Abp.Localization;
using Roc.CMS.Install.Dto;

namespace Roc.CMS.Web.Models.Install
{
    public class InstallViewModel
    {
        public List<ApplicationLanguage> Languages { get; set; }

        public AppSettingsJsonDto AppSettingsJson { get; set; }
    }
}
