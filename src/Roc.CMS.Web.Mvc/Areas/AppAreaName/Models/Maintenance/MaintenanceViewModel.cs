using System.Collections.Generic;
using Roc.CMS.Caching.Dto;

namespace Roc.CMS.Web.Areas.AppAreaName.Models.Maintenance
{
    public class MaintenanceViewModel
    {
        public IReadOnlyList<CacheDto> Caches { get; set; }
    }
}