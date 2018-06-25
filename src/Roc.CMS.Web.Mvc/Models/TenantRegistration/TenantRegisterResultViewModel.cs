using Abp.AutoMapper;
using Roc.CMS.MultiTenancy.Dto;

namespace Roc.CMS.Web.Models.TenantRegistration
{
    [AutoMapFrom(typeof(RegisterTenantOutput))]
    public class TenantRegisterResultViewModel : RegisterTenantOutput
    {
        public string TenantLoginAddress { get; set; }
    }
}