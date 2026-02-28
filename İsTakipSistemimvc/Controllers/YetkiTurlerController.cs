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
    [Authorize]
    public class YetkiTurlerController : Controller
    {
        private IsTakipContext db = new IsTakipContext();

        // GET: YetkiTurler
        public ActionResult Index()
        {
            return View(db.YetkiTurler.ToList());
        }

        // GET: YetkiTurler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YetkiTur yetkiTur = db.YetkiTurler.Find(id);
            if (yetkiTur == null)
            {
                return HttpNotFound();
            }
            return View(yetkiTur);
        }

        // GET: YetkiTurler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: YetkiTurler/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "YetkiTurId,YetkiAd")] YetkiTur yetkiTur)
        {
            if (ModelState.IsValid)
            {
                db.YetkiTurler.Add(yetkiTur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yetkiTur);
        }

        // GET: YetkiTurler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YetkiTur yetkiTur = db.YetkiTurler.Find(id);
            if (yetkiTur == null)
            {
                return HttpNotFound();
            }
            return View(yetkiTur);
        }

        // POST: YetkiTurler/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "YetkiTurId,YetkiAd")] YetkiTur yetkiTur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yetkiTur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yetkiTur);
        }

        // GET: YetkiTurler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YetkiTur yetkiTur = db.YetkiTurler.Find(id);
            if (yetkiTur == null)
            {
                return HttpNotFound();
            }
            return View(yetkiTur);
        }

        // POST: YetkiTurler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            YetkiTur yetkiTur = db.YetkiTurler.Find(id);
            db.YetkiTurler.Remove(yetkiTur);
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
