using System.Collections.Generic;
using Roc.CMS.Caching.Dto;

namespace Roc.CMS.Web.Areas.Sys.Models.Maintenance
{
    public class MaintenanceViewModel
    {
        public IReadOnlyList<CacheDto> Caches { get; set; }
    }
}