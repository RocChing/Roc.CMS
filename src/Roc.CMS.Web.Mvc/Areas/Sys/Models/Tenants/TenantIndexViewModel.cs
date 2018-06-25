using System.Collections.Generic;
using Roc.CMS.Editions.Dto;

namespace Roc.CMS.Web.Areas.Sys.Models.Tenants
{
    public class TenantIndexViewModel
    {
        public List<SubscribableEditionComboboxItemDto> EditionItems { get; set; }
    }
}