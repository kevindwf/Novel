using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using Model.DBEntity;
using Model;
using System.IO;

namespace Data.CapturedData
{
    public class Index
    {
        private string _html = string.Empty;
        private List<NovelInfo> _novels; 
        
        public Index(string url)
        {
            _html = HttpWebRequestHelper.PostDataToUrl(url, "");
            _novels = GetNovels();
        }

        public List<NovelInfo> GetSuggestNovels()
        {
            return _novels.GetRange(44, 21);
        }

        public List<NovelInfo> GetFinishedNovels()
        {
            return _novels.GetRange(22, 22);
        }

        public List<NovelInfo> GetTopViewNovels()
        {
            return _novels.GetRange(0, 22);
        }

        public List<NovelInfo> GetLatestNovels()
        {
            return _novels.GetRange(63, 21);
        }

        public List<ChapterInfo> GetLatestChapters()
        {
            var chapters = new List<ChapterInfo>();
            Regex regex = new Regex(@"<li\s*class=""fl\s*lm""\s*style=""width:70%;"">\[(.*?)\]\s*《<a\s*class=""poptext""\s*href=""(.*?)""\s*target=""_blank"">(.*?)</a>》\s*<a\s*href=""(.*?)""\s*target=""_blank"">(.*?)</a></li><li\s*class=""fr\s*tr""\s*style=""width:30%;"">(.*?)</li>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            var matches = regex.Matches(_html);
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    chapters.Add(new ChapterInfo
                    {
                        Novel = new NovelInfo()
                        {
                            NovelType = match.Groups[1].Value,
                            NovelUrl = match.Groups[2].Value,
                            NovelName = match.Groups[3].Value,
                            NovelAuthor = match.Groups[6].Value,
                        },
                        ChapterUrl = match.Groups[4].Value,
                        ChapterName = match.Groups[5].Value,
                    });
                }
            }

            return chapters;
        }

        public List<NovelInfo> GetImageNovels()
        {
            var novels = new List<NovelInfo>();
            var regex = new Regex(@"<li\s*class=""qianglei_ul"">\s*<a\s*href=""(.*?)""\s*target=""_blank""\s*class=""imga""><img\s*src=""(.*?)""\s*border=""0""\s*width=""100""\s*height=""125""\s*alt="".*?""></a>\s*<p\s*class=""name"">\s*<a\s*href="".*?\s*target=""_blank"">《(.*?)》</a><p>\s*<em>(.*?)</em>\s*</li>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            var matches = regex.Matches(_html);
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    novels.Add(new NovelInfo
                    {
                        NovelUrl=match.Groups[1].Value,
                        NovelImage=match.Groups[2].Value,
                        NovelName=match.Groups[3].Value,
                        NovelDesc=match.Groups[4].Value
                    });
                }
            }

            return novels;
        }

        #region private method

        private List<NovelInfo> GetNovels()
        {
            var novels = new List<NovelInfo>();
            Regex regex = new Regex(@"<li><a\s*href=""(.*?)""\s*target=""_blank"">(.*?)</a></li>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            var matches = regex.Matches(_html);
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    novels.Add(new NovelInfo
                    {
                        NovelUrl = match.Groups[1].Value,
                        NovelName = match.Groups[2].Value,
                    });
                }
            }

            return novels;
        }

        #endregion
    }
}
