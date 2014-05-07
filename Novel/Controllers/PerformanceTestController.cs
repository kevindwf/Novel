using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Novel.Data;
using Model;

namespace Novel.Controllers
{
    public class PerformanceTestController : Controller
    {
        //
        // GET: /PerformanceTest/

        [HttpGet]
        public ActionResult GetChapter()
        {
            NovelDB novelDB = new NovelDB();
            int chapterId = int.Parse(Request.Path.Split('/')[3]);
            var chapter = novelDB.GetChapterById(chapterId);
            ViewData["NovelChapter"] = chapter.ChapterName;
            return View();
        }


    }
}
