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
    public class AdminBolumController : Controller
    {
        private mvcTakipDB db = new mvcTakipDB();

        // GET: AdminBolum
        public ActionResult Index()
        {
            return View(db.tblBolums.ToList());
        }

        // GET: AdminBolum/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBolum tblBolum = db.tblBolums.Find(id);
            if (tblBolum == null)
            {
                return HttpNotFound();
            }
            return View(tblBolum);
        }

        // GET: AdminBolum/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminBolum/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Bolum")] tblBolum tblBolum)
        {
            if (ModelState.IsValid)
            {
                db.tblBolums.Add(tblBolum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblBolum);
        }

        // GET: AdminBolum/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBolum tblBolum = db.tblBolums.Find(id);
            if (tblBolum == null)
            {
                return HttpNotFound();
            }
            return View(tblBolum);
        }

        // POST: AdminBolum/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Bolum")] tblBolum tblBolum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblBolum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblBolum);
        }

        // GET: AdminBolum/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBolum tblBolum = db.tblBolums.Find(id);
            if (tblBolum == null)
            {
                return HttpNotFound();
            }
            return View(tblBolum);
        }

        // POST: AdminBolum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblBolum tblBolum = db.tblBolums.Find(id);
            db.tblBolums.Remove(tblBolum);
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
