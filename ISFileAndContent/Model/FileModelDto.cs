using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFileAndContent.Model
{
    public class FileModelDto : Object
    {
        public string DirectoryName { get; set; }

        public string BizName { get; set; }

        public string FileName { get; set; }

        public string ShowName { get; set; }

        /// <summary>
        /// 文件创建/完成时间
        /// </summary>
        public DateTime FileOn { get; set; }

        public string FilePath { get; set; }

        public int Status { get; set; }

        public string FileSize { get; set; }

        public string Msg { get; set; }
    }

    public enum TaskStatus : int
    {
        /// <summary>
        /// 等待
        /// </summary>
        Watting = 1,
        /// <summary>
        /// 执行中
        /// </summary>
        Executing = 2,
        /// <summary>
        /// 执行完成
        /// </summary>
        Finish = 3,
        /// <summary>
        /// 执行失败
        /// </summary>
        Fail = 4
    }
}
