using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roc.CMS.Content
{
    public class CategoryCreateOrEditOutput
    {
        public CategoryDto Category { get; set; }

        public List<ComboboxItemDto> Categories { get; set; }

        public List<ComboboxItemDto> Targets { get; set; }

        public bool IsEditMode { get; set; }

        public CategoryCreateOrEditOutput()
        {

        }

        public string GetTrueOrFalseValue(bool flag)
        {
            return flag.ToString().ToLowerInvariant();
        }
    }
}
