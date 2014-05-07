using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Text.RegularExpressions;

namespace Data.CapturedData
{
    public class NovelList
    {
        private string _html = string.Empty;

        public NovelList(string url)
        {
            _html = HttpWebRequestHelper.PostDataToUrl(url, "");

        }

        public List<ChapterInfo> GetNovelList()
        {
            var chapters = new List<ChapterInfo>();
            Regex regex = new Regex(@"<tr>\s*<td class=""odd""><a href=""(.*?)"">(.*?)</a></td>\s*<td class=""even""><a href=""(.*?)"" target=""_blank"">(.*?)</a></td>\s*<td class=""odd"">(.*?)</td>\s*<td class=""even"" align=""center"">(.*?)</td>\s*<td class=""odd"" align=""center"">(.*?)</td>\s*</tr>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            var matches = regex.Matches(_html);
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    DateTime latestUpdateDate;
                    DateTime.TryParse("20"+match.Groups[6].Value, out latestUpdateDate);

                    chapters.Add(new ChapterInfo
                    {
                        Novel = new NovelInfo()
                        {
                            NovelUrl = match.Groups[1].Value,
                            NovelName = match.Groups[2].Value,
                            NovelAuthor = match.Groups[5].Value,
                            LatestUpdateDate = latestUpdateDate,
                            IsFinished = string.Compare(match.Groups[7].Value, "已完成", true) == 0,
                        },
                        ChapterUrl = match.Groups[3].Value,
                        ChapterName = match.Groups[4].Value,
                    });
                }
            }

            return chapters;
        }
    }
}
