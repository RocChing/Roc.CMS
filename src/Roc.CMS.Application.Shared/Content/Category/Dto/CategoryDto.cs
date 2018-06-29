using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Roc.CMS.Content
{
    public class CategoryDto
    {
        public CategoryDto()
        {
            SortId = 100; 
        }

        public virtual int? Id { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 分类名称
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        /// <summary>
        ///父类ID
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [MaxLength(500)]
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
        [MaxLength(400)]
        public string URL { get; set; }

        /// <summary>
        /// target类型
        /// </summary>
        public CategoryTarget Target { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int? SortId { get; set; }
    }
}
