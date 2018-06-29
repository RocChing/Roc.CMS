using Abp.Runtime.Validation;
using Roc.CMS.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roc.CMS.Content
{
    public class CategoryListInput : PagedAndSortedInputDto, IShouldNormalize
    {
        public string Filter { get; set; }

        public int? ParentId { get; set; }

        public string ParentCode { get; set; }

        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "ParentId,Id";
            }
        }
    }
}
