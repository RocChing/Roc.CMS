using System;
using Abp.Application.Services.Dto;

namespace Roc.CMS.Content
{
    public class CategoryDto : EntityDto
    {
        public int? TenantId { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 分类名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 分类代码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        ///父类ID
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 是否是导航
        /// </summary>
        public bool IsNav { get; set; }

        /// <summary>
        /// 是否是特殊
        /// </summary>
        public bool IsSpecial { get; set; }

        /// <summary>
        /// URL地址
        /// </summary>
        public string URL { get; set; }

        /// <summary>
        /// target类型
        /// </summary>
        public CategoryTarget Target { get; set; }
    }
}
