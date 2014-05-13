using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.CapturedData;


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
            string url = string.Format("http://www.cxzww.com/shtml/{0}/{1}/", chapterId.ToString().Substring(0, 2), chapterId);
            Chapter chapter = new Chapter(url);

            ViewData["Chapters"] = chapter.GetChapters();
            ViewData["ChapterInfo"] = chapter.GetChapterInfo();

            return View();
        }

        public ActionResult Content(int chapterId, int contentId)
        {
            string url = string.Format("http://www.cxzww.com/shtml/{0}/{1}/{2}.html", chapterId.ToString().Substring(0, 2), chapterId, contentId);
            Content content = new Content(url);

            ViewData["Content"] = content.GetNovelContent();

            return View();
        }

        
    }
}
