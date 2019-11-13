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
    public class HomeController : Controller
    {
        mvcTakipDB db = new mvcTakipDB();
        // GET: Home
        public ActionResult Index(int Page=1)
        {
            var kisi = db.tblKisis.OrderByDescending(k => k.id).ToPagedList(Page,6);
            return View(kisi);
        }
        public ActionResult Ara(string ara = null)
        {
            var aranan = db.tblKisis.Where(k => k.Adi.Contains(ara)).ToList();
            return View(aranan.OrderByDescending(k=>k.MezunYil));
        }
        public ActionResult BolumKisi(int id)
        {
            var kisiler = db.tblKisis.Where(k => k.BolumId == id).ToList();
            return View(kisiler);
        }
        public ActionResult KisiDetay(int id)
        {
            var kisi = db.tblKisis.Where(k => k.id == id).SingleOrDefault();
            if (kisi == null)
            {
                return HttpNotFound();
            }
            return View(kisi);
        }
        public ActionResult BolumPartial()
        {
            return View(db.tblBolums.ToList());
        }
    }
}