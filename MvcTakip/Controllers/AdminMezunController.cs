using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTakip.Models;
using PagedList;
using PagedList.Mvc;

namespace MvcTakip.Controllers
{
    public class AdminMezunController : Controller
    {
        mvcTakipDB db = new mvcTakipDB();
        // GET: AdminMezun
        public ActionResult Index(int Page=1)
        {
            var mezun = db.tblKisis.OrderByDescending(m => m.id).ToPagedList(Page, 6);
            return View(mezun);
        }
    }
}