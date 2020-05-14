using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFileAndContent.FolderUtil
{
    public class DataCollection<T> : PageDto where T :class
    {
        /// <summary>
        /// pagelist
        /// </summary>
        public List<T> data { get; set; }
    }
}
