using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTakip.Models;
using System.Web.Helpers;
using System.IO;

namespace MvcTakip.Controllers
{
    public class UyeController : Controller
    {
        mvcTakipDB db = new mvcTakipDB();
        // GET: Uye
        public ActionResult Index(int id)
        {
            var uye = db.tblKisis.Where(u => u.id == id).SingleOrDefault();
            if (Convert.ToInt32(Session["uyeid"]) != uye.id)
            {
                return HttpNotFound();
            }
            return View(uye);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(tblKisi uye)
        {
            
            var login = db.tblKisis.Where(u => u.Eposta == uye.Eposta).SingleOrDefault();
            if(login.Eposta == uye.Eposta && login.Sifre == uye.Sifre)
            {
                Session["uyeid"] = login.id;
                Session["email"] = login.Eposta;
                Session["yetkiId"] = login.YetkiId;
                Session["adi"] = login.Adi;
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ViewBag.Uyari = true;
                return View();
            }
            
        }
        public ActionResult Logout()
        {
            Session["uyeid"] = null;
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Create()
        {
            ViewBag.BolumId = new SelectList(db.tblBolums, "id", "Bolum");
            
            return View();
        }
        [HttpPost]
        public ActionResult Create(tblKisi uye, HttpPostedFileBase Foto)
        {
            if (ModelState.IsValid) {
                if (Foto != null) {
                    WebImage img = new WebImage(Foto.InputStream);
                    FileInfo fotoinfo = new FileInfo(Foto.FileName);
                    string newfoto = Guid.NewGuid().ToString() + fotoinfo.Extension;
                    img.Resize(150, 150);
                    img.Save("~/Uploads/MezunFoto/" + newfoto);
                    uye.Foto = "/Uploads/MezunFoto/" + newfoto;
                    uye.YetkiId = 2;
                    db.tblKisis.Add(uye);
                    db.SaveChanges();
                    Session["uyeid"] = uye.id;
                    Session["email"] = uye.Eposta;
                    Session["adi"] = uye.Adi;
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ModelState.AddModelError("Fotograf", "Fotograf Seciniz");
                }
            }
            return View(uye);
        }
        public ActionResult Edit(int id)
        {
            var uye = db.tblKisis.Where(u => u.id == id).SingleOrDefault();
            if (Convert.ToInt32(Session["uyeid"]) != uye.id)
            {
                return HttpNotFound();
            }
            
            return View(uye);
        }
        [HttpPost]
        public ActionResult Edit(tblKisi uye, int id, HttpPostedFileBase Foto)
        {
            if (ModelState.IsValid)
            {
                var uyes = db.tblKisis.Where(u => u.id == id).SingleOrDefault();
                if (Foto != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(uye.Foto)))
                    {
                        System.IO.File.Delete(Server.MapPath(uyes.Foto));
                    }
                    WebImage img = new WebImage(Foto.InputStream);
                    FileInfo fotoinfo = new FileInfo(Foto.FileName);

                    string newfoto = Guid.NewGuid().ToString() + fotoinfo.Extension;
                    img.Resize(150, 150);
                    img.Save("~/Uploads/MezunFoto/" + newfoto);
                    uyes.Foto = "/Uploads/MezunFoto/" + newfoto;
                }
                uyes.Adi = uye.Adi;
                uyes.Soyadi = uye.Soyadi;
                uyes.Eposta = uye.Eposta;
                uyes.Sifre = uye.Sifre;
                uyes.CalistigiYer = uye.CalistigiYer;
                db.SaveChanges();

                Session["adi"] = uye.Adi;
                Session["uyeid"] = uye.id;
                return RedirectToAction("Index", "Home", new { id = uyes.id });
            }
            return View();
        }
    }
}