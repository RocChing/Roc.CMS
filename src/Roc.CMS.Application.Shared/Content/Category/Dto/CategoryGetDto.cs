using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roc.CMS.Content
{
    public class CategoryGetDto : NullableIdDto
    {
        public bool UseCodeValue { get; set; }

        public CategoryGetDto()
        {

        }

        public CategoryGetDto(int? id, bool useCodeValue = false) : base(id)
        {
            UseCodeValue = useCodeValue;
        }
    }
}
