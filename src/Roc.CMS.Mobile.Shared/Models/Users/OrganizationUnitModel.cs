using Abp.AutoMapper;
using Roc.CMS.Organizations.Dto;

namespace Roc.CMS.Models.Users
{
    [AutoMapFrom(typeof(OrganizationUnitDto))]
    public class OrganizationUnitModel : OrganizationUnitDto
    {
        public bool IsAssigned { get; set; }
    }
}