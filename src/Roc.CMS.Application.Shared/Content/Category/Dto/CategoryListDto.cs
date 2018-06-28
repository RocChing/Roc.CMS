using System;
using Abp.Application.Services.Dto;

namespace Roc.CMS.Content
{
    public class CategoryListDto : EntityDto
    {
        /// <summary>
        /// 分类名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///父类ID
        /// </summary>
        public int ParentId { get; set; }

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

        /// <summary>
        /// 上级名称
        /// </summary>
        public string ParentName { get; set; }
    }
}
