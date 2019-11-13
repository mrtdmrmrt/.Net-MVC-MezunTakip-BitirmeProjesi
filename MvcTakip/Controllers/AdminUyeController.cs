using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcTakip.Models;

namespace MvcTakip.Controllers
{
    public class AdminUyeController : Controller
    {
        private mvcTakipDB db = new mvcTakipDB();

        // GET: AdminUye
        public ActionResult Index()
        {
            var tblKisis = db.tblKisis.Include(t => t.tblBolum).Include(t => t.tblYetki);
            return View(tblKisis.OrderByDescending(u=>u.id).ToList());
        }

        // GET: AdminUye/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblKisi tblKisi = db.tblKisis.Find(id);
            if (tblKisi == null)
            {
                return HttpNotFound();
            }
            return View(tblKisi);
        }

        // GET: AdminUye/Create
        public ActionResult Create()
        {
            ViewBag.BolumId = new SelectList(db.tblBolums, "id", "Bolum");
            ViewBag.YetkiId = new SelectList(db.tblYetkis, "id", "Yetki");
            return View();
        }

        // POST: AdminUye/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Adi,Soyadi,CalistigiYer,Agno,MezunYil,Eposta,Sifre,YetkiId,Foto,BolumId,Staj1,Staj2,IsYeriEgitimi")] tblKisi tblKisi)
        {
            if (ModelState.IsValid)
            {
                db.tblKisis.Add(tblKisi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BolumId = new SelectList(db.tblBolums, "id", "Bolum", tblKisi.BolumId);
            ViewBag.YetkiId = new SelectList(db.tblYetkis, "id", "Yetki", tblKisi.YetkiId);
            return View(tblKisi);
        }

        // GET: AdminUye/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblKisi tblKisi = db.tblKisis.Find(id);
            if (tblKisi == null)
            {
                return HttpNotFound();
            }
            ViewBag.BolumId = new SelectList(db.tblBolums, "id", "Bolum", tblKisi.BolumId);
            ViewBag.YetkiId = new SelectList(db.tblYetkis, "id", "Yetki", tblKisi.YetkiId);
            return View(tblKisi);
        }

        // POST: AdminUye/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Adi,Soyadi,CalistigiYer,Agno,MezunYil,Eposta,Sifre,YetkiId,Foto,BolumId,Staj1,Staj2,IsYeriEgitimi")] tblKisi tblKisi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblKisi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BolumId = new SelectList(db.tblBolums, "id", "Bolum", tblKisi.BolumId);
            ViewBag.YetkiId = new SelectList(db.tblYetkis, "id", "Yetki", tblKisi.YetkiId);
            return View(tblKisi);
        }

        // GET: AdminUye/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblKisi tblKisi = db.tblKisis.Find(id);
            if (tblKisi == null)
            {
                return HttpNotFound();
            }
            return View(tblKisi);
        }

        // POST: AdminUye/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblKisi tblKisi = db.tblKisis.Find(id);
            db.tblKisis.Remove(tblKisi);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
