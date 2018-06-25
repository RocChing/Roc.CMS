using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Roc.CMS.Editions.Dto;

namespace Roc.CMS.MultiTenancy.Dto
{
    public class GetTenantFeaturesEditOutput
    {
        public List<NameValueDto> FeatureValues { get; set; }

        public List<FlatFeatureDto> Features { get; set; }
    }
}