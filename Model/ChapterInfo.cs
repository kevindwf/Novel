using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ChapterInfo
    {
        public int ChapterId { get; set; }

        public NovelInfo Novel { get; set; }

        public string ChapterName { get; set; }

        public string ChapterUrl { get; set; }

        public int ChapterOrder { get; set; }

        public string ChapterContent { get; set; }

        /// <summary>
        /// IsSubTitle:
        /// true:   <dt>韩娱之天王 正文</dt>
        /// false:  <dd><a href="6954767.html">第一章 服役</a></dd>
        /// </summary>
        public bool IsSubTitle { get; set; }

        public string NextChapterUrl { get; set; }

        public string PreviousChapterUrl { get; set; }
    }
}
