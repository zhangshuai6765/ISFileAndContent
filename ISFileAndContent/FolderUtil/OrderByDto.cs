using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFileAndContent.FolderUtil
{
    //public class OrderbyCollection
    //{
    //    public List<OrderbyDto> OrderBy { get; set; }
    //}

    public class OrderByDto
    {
        /// <summary>
        /// 排序字段名
        /// </summary>
        public string SortName { get; set; }

        /// <summary>
        /// 正序还是倒序
        /// </summary>
        public bool Desc { get; set; }

        /// <summary>
        /// 排序字段类型
        /// </summary>
        public Type t { get; set; }
    }
}
