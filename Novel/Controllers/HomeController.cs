using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.CapturedData;
using Model;


namespace Novel.Controllers
{
    [HandleError]
    public class HomeController : BaseNovelController
    {
        public ActionResult Index()
        {
            Index indexDB = new Index("http://www.cxzww.com/");

            ViewData["TopViewNovels"] = indexDB.GetTopViewNovels();
            ViewData["SuggestNovels"] = indexDB.GetSuggestNovels();
            ViewData["FinishedNovels"] = indexDB.GetFinishedNovels();
            ViewData["LatestNovels"] = indexDB.GetLatestNovels();
            ViewData["LatestChapters"] = indexDB.GetLatestChapters();
            ViewData["ImageNovels"] = indexDB.GetImageNovels();
            

            return View();
        }

        public ActionResult NovelList(string category, int index=1)
        {
            Category categoryDB = new Category();
            int categoryId = categoryDB.GetCategoryIdByUrl(category);
            string url;
            if (index == 1)
            {
                url = string.Format("http://www.cxzww.com/sortid_{0}/", categoryId);
            }
            else
            {
                url = string.Format("http://www.cxzww.com/sortid_{0}/{1}/", categoryId, index);
            }
            NovelList novelList = new NovelList(url);

            ViewData["NovelList"] = novelList.GetNovelList();

            return View();
        }

        public ActionResult Chapter(int chapterId)
        {
            chapterId = IdMappingHelper.DecodeId(chapterId);

            string url = string.Format("http://www.cxzww.com/shtml/{0}/{1}/", GetNovelPrefix(chapterId), chapterId);
            Chapter chapter = new Chapter(url);

            ViewData["Chapters"] = chapter.GetChapters();
            ViewData["ChapterInfo"] = chapter.GetChapterInfo();

            return View();
        }

        public ActionResult Content(int chapterId, int contentId)
        {
            chapterId = IdMappingHelper.DecodeId(chapterId);
            contentId = IdMappingHelper.DecodeId(contentId);
            string url = string.Format("http://www.cxzww.com/shtml/{0}/{1}/{2}.html", GetNovelPrefix(chapterId), chapterId, contentId);
            Content content = new Content(url);

            ViewData["Content"] = content.GetNovelContent();

            return View();
        }

        private string GetNovelPrefix(int chapterId)
        {
            //http://www.cxzww.com/shtml/0/291/
            if (chapterId < 1000)
            {
                return "0";
            }

            //http://www.cxzww.com/shtml/64/64458/
            return chapterId.ToString().Substring(0, 2);
        }
    }
}
