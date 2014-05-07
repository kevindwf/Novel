using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Novel.Controllers
{
    public class NovelListController : Controller
    {
        //
        // GET: /NovelList/

        public ActionResult Index()
        {
            return View();
        }

    }
}
