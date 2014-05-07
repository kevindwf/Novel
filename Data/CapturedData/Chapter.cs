using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Text.RegularExpressions;

namespace Data.CapturedData
{
    public class Chapter
    {
        private string _html = string.Empty;

        public Chapter(string url)
        {
            _html = HttpWebRequestHelper.PostDataToUrl(url, "");

        }

        public List<ChapterInfo> GetChapters()
        {
            var chapters = new List<ChapterInfo>();
            Regex regex = new Regex(@"<dt>(.*?)<\/dt>|<dd><a\s*href=""(.*?)"">(.*?)<\/a><\/dd>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            var matches = regex.Matches(_html);
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    DateTime latestUpdateDate;
                    DateTime.TryParse("20"+match.Groups[6].Value, out latestUpdateDate);

                    if (string.IsNullOrEmpty(match.Groups[1].Value))
                    {
                        chapters.Add(new ChapterInfo
                        {
                            IsSubTitle = false,
                            ChapterUrl = match.Groups[2].Value,
                            ChapterName = match.Groups[3].Value,
                        });
                    }
                    else
                    {
                        chapters.Add(new ChapterInfo
                        {
                            IsSubTitle = true,
                            ChapterName = match.Groups[1].Value,
                        });
                    }
                }
            }

            return chapters;
        }

        public ChapterInfo GetChapterInfo()
        {
            var chapterInfo = new ChapterInfo();
            var regex = new Regex(@"<div\s*id=""title""><h1>(.*?)<\/h1><\/div>\s*<div\s*id=""msg"">作者：(.*?) \| 类型：(.*?) \| 最新：<a href=""(.*?)"">(.*?)<\/a><\/div>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            var matches = regex.Matches(_html);
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    chapterInfo = new ChapterInfo()
                    {
                        Novel = new NovelInfo()
                        {
                            NovelName = match.Groups[1].Value,
                            NovelAuthor = match.Groups[2].Value,
                            NovelType = match.Groups[3].Value,
                        },
                        ChapterUrl = match.Groups[4].Value,
                        ChapterName = match.Groups[5].Value,
                    };
                }
            }

            return chapterInfo;
        }
    }
}
