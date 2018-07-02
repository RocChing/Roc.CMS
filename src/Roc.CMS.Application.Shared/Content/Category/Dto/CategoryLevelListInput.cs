using System;
using System.Collections.Generic;
using System.Text;

namespace Roc.CMS.Content
{
    public class CategoryLevelListInput
    {
        /// <summary>
        /// 前缀字符串 默认空
        /// </summary>
        public string Pre { get; set; }

        /// <summary>
        /// 重复字符串 默认--
        /// </summary>
        public string Repeat { get; set; }

        /// <summary>
        /// 是否使用code
        /// </summary>
        public bool UseCodeValue { get; set; }

        /// <summary>
        /// 选中值
        /// </summary>
        public string SelectedValue { get; set; }

        public CategoryLevelListInput()
        {
            Pre = "";
            Repeat = "--";
        }
    }
}
