using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFileAndContent.FolderUtil
{
    public class PageDto
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public int PageCount { get; set; }

        public int TotalCount { get; set; }
    }
}
