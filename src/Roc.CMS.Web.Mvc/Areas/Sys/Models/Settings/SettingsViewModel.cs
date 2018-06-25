using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Roc.CMS.Configuration.Tenants.Dto;

namespace Roc.CMS.Web.Areas.Sys.Models.Settings
{
    public class SettingsViewModel
    {
        public TenantSettingsEditDto Settings { get; set; }
        
        public List<ComboboxItemDto> TimezoneItems { get; set; }
    }
}