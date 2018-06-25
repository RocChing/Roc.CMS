using System.Collections.Generic;
using Roc.CMS.Organizations.Dto;

namespace Roc.CMS.Web.Areas.Sys.Models.Common
{
    public interface IOrganizationUnitsEditViewModel
    {
        List<OrganizationUnitDto> AllOrganizationUnits { get; set; }

        List<string> MemberedOrganizationUnits { get; set; }
    }
}