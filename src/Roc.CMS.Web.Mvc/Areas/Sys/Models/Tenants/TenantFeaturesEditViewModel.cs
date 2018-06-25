using Abp.AutoMapper;
using Roc.CMS.MultiTenancy;
using Roc.CMS.MultiTenancy.Dto;
using Roc.CMS.Web.Areas.Sys.Models.Common;

namespace Roc.CMS.Web.Areas.Sys.Models.Tenants
{
    [AutoMapFrom(typeof (GetTenantFeaturesEditOutput))]
    public class TenantFeaturesEditViewModel : GetTenantFeaturesEditOutput, IFeatureEditViewModel
    {
        public Tenant Tenant { get; set; }

        public TenantFeaturesEditViewModel(Tenant tenant, GetTenantFeaturesEditOutput output)
        {
            Tenant = tenant;
            output.MapTo(this);
        }
    }
}