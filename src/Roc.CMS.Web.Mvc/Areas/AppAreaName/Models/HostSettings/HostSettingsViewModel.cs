using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Roc.CMS.Configuration.Host.Dto;
using Roc.CMS.Editions.Dto;

namespace Roc.CMS.Web.Areas.AppAreaName.Models.HostSettings
{
    public class HostSettingsViewModel
    {
        public HostSettingsEditDto Settings { get; set; }

        public List<SubscribableEditionComboboxItemDto> EditionItems { get; set; }

        public List<ComboboxItemDto> TimezoneItems { get; set; }
    }
}