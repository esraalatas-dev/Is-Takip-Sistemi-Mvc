using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IsTakipSistemiMvc.Models;

namespace İsTakipSistemimvc.Controllers
{
    public class BirimsController : Controller
    {
        private IsTakipContext db = new IsTakipContext();

        // GET: Birims
        public ActionResult Index()
        {
            return View(db.Birimler.ToList());
        }

        // GET: Birims/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Birim birim = db.Birimler.Find(id);
            if (birim == null)
            {
                return HttpNotFound();
            }
            return View(birim);
        }

        // GET: Birims/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Birims/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BirimId,BirimAd")] Birim birim)
        {
            if (ModelState.IsValid)
            {
                db.Birimler.Add(birim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(birim);
        }

        // GET: Birims/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Birim birim = db.Birimler.Find(id);
            if (birim == null)
            {
                return HttpNotFound();
            }
            return View(birim);
        }

        // POST: Birims/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BirimId,BirimAd")] Birim birim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(birim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(birim);
        }

        // GET: Birims/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Birim birim = db.Birimler.Find(id);
            if (birim == null)
            {
                return HttpNotFound();
            }
            return View(birim);
        }

        // POST: Birims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Birim birim = db.Birimler.Find(id);
            db.Birimler.Remove(birim);
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
