using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Text.RegularExpressions;

namespace Data.CapturedData
{
    public class Content
    {
        private string _html = string.Empty;

        public Content(string url)
        {
            _html = HttpWebRequestHelper.PostDataToUrl(url, "");

        }

        public ChapterInfo GetNovelContent()
        {
            var chapter = new ChapterInfo() { Novel = new NovelInfo() };
            Regex chapterRegex = new Regex(@"<td class=""tddh""><a href=""(.*?)"">.*?<\/a><\/td>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            
            var chapterMatch = chapterRegex.Match(_html);
            chapter.PreviousChapterUrl = chapterMatch.Groups[1].Value;
            chapter.Novel.NovelUrl = chapterMatch.NextMatch().Groups[1].Value;
            chapter.NextChapterUrl = chapterMatch.NextMatch().Groups[1].Value;

            Regex hiarachyRegex = new Regex(@"&nbsp;&raquo;&nbsp;<a href=""(.*?)"">(.*?)&nbsp;&raquo;&nbsp;<a href=""(.*?)"">(.*?)&nbsp;&raquo;&nbsp;(.*?)<\/div>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            var hiarachyMatches = hiarachyRegex.Matches(_html);
            if (hiarachyMatches.Count > 0)
            {
                chapter.Novel.NovelCategory = new NovelCategoryInfo(hiarachyMatches[0].Groups[2].Value);
                chapter.Novel.NovelUrl = hiarachyMatches[0].Groups[3].Value;
                chapter.Novel.NovelName = hiarachyMatches[0].Groups[4].Value;
                chapter.ChapterName = hiarachyMatches[0].Groups[5].Value;
            }

            Regex contentRegex = new Regex(@"<script >content\(\);<\/script>(.*)<script >fyup\(\);<\/script><\/div>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            var contentMatch = contentRegex.Match(_html);
            if (contentMatch.Success)
            {
                chapter.ChapterContent = contentMatch.Value;
            }

            return chapter;
        }
    }
}
