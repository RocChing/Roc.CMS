using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace Roc.CMS.Web.Areas.AppAreaName.Models.Roles
{
    public class RoleListViewModel
    {
        public List<ComboboxItemDto> Permissions { get; set; }
    }
}