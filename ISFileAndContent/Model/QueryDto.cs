using ISFileAndContent.FolderUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFileAndContent.Model
{
    public class QueryDto : PageDto
    {
        public int Status { get; set; }

        public DateTime? StartFileOn { get; set; }

        public DateTime? EndFileOn { get; set; }

        public string BizName { get; set; }

        public string FileName { get; set; }


        #region 内容搜索相关参数

        /// <summary>
        /// 是否开启内容搜索
        /// </summary>
        public bool OpenKey { get; set; }

        /// <summary>
        /// 内容关键字
        /// </summary>
        public string ContentKey { get; set; }

        #endregion
    }
}
