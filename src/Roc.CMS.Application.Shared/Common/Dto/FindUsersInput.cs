using Roc.CMS.Dto;

namespace Roc.CMS.Common.Dto
{
    public class FindUsersInput : PagedAndFilteredInputDto
    {
        public int? TenantId { get; set; }
    }
}