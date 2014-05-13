using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.CapturedData;

namespace Novel.Controllers
{
    public class BaseNovelController : Controller
    {
        //
        // GET: /BaseNovel/

        public BaseNovelController()
        {
            ViewData["Category"] = new Category().GetNovelCategoryLookupList();
        }

    }
}
