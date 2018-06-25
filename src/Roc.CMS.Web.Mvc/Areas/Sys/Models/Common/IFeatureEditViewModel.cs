using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Roc.CMS.Editions.Dto;

namespace Roc.CMS.Web.Areas.Sys.Models.Common
{
    public interface IFeatureEditViewModel
    {
        List<NameValueDto> FeatureValues { get; set; }

        List<FlatFeatureDto> Features { get; set; }
    }
}