using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ChapterInfo
    {
        private string m_ChapterUrl;

        public int ChapterId 
        { 
            get
            {
                int id;
                int.TryParse(m_ChapterUrl.Split('/').Last().Replace(".html", ""), out id);
                return IdMappingHelper.EncodeId(id);
            }
        }

        public NovelInfo Novel { get; set; }

        public string ChapterName { get; set; }

        public string ChapterUrl 
        {
            get
            {
                //output: /content/[decode novelId]/[decode chapterId]
                var tempUrl = m_ChapterUrl.Replace("http://www.cxzww.com/","").Replace(".html","");
                int novelId = int.Parse(tempUrl.TrimStart('/').Split('/')[2]);
                //if (string.IsNullOrEmpty(Novel.NovelUrl))
                //    Novel.NovelUrl = m_ChapterUrl.Substring(0, m_ChapterUrl.LastIndexOf('/'));
                return string.Format("/content/{0}/{1}", IdMappingHelper.EncodeId(novelId), ChapterId);
            }
            set
            {
                //input: http://www.cxzww.com/shtml/78/78344/11571102.html
                m_ChapterUrl = value;
            }
        }

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
