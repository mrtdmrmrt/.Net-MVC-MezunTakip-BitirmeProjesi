using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTakip.Models;

namespace MvcTakip.Controllers
{
    public class AdminController : Controller
    {
        mvcTakipDB db = new mvcTakipDB();
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.MezunSayisi = db.tblKisis.Count();
            ViewBag.BolumSayisi = db.tblBolums.Count();
            return View();
        }
    }
}