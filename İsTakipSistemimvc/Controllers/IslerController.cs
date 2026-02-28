using İsTakipSistemimvc.Controllers;
using IsTakipSistemiMvc.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web.Mvc;

namespace IsTakipSistemiMvc.Controllers
{
    [Authorize]   /*sadece giriş yapanlar erişebilir*/
    public class IslerController : Controller
    {
        private IsTakipContext db = new IsTakipContext();   /*veritabanıyla bağlantı kurma */

        public ActionResult Index()
        {
            var isler = db.Isler.Include(i => i.Durum).Include(i => i.Personel); /*işler tablosunu çekerken durum ve peroselleri de çek*/
            return View(isler.ToList());  /*listeyi wieve gönder*/
        }


        // Bu etiket, linkin istenilen formatda çalışmasını sağlar.

        [Route("is-detay/{baslik}-{id:int}")]    /* -> SEO-URL için*/
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Is @is = db.Isler.Find(id);
            if (@is == null)
            {
                return HttpNotFound();
            }
            return View(@is);
        }

        public ActionResult Create()
        {
            //Durumlar ve personelleri verit. çekip viewe gönder

            ViewBag.DurumId = new SelectList(db.Durumlar, "DurumId", "DurumAd");
            ViewBag.PersonelId = new SelectList(db.Personeller, "PersonelId", "AdSoyad");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)] // CKEditor HTML izni için (güvenlik doğrulamasını önlemek için...)
        public ActionResult Create([Bind(Include = "IsId,Baslik,Aciklama,Tarih,PersonelId,DurumId")] Is @is)
        {
            if (ModelState.IsValid)
            {
                db.Isler.Add(@is);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DurumId = new SelectList(db.Durumlar, "DurumId", "DurumAd", @is.DurumId);
            ViewBag.PersonelId = new SelectList(db.Personeller, "PersonelId", "AdSoyad", @is.PersonelId);
            return View(@is);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Is @is = db.Isler.Find(id);
            if (@is == null) return HttpNotFound();
            ViewBag.DurumId = new SelectList(db.Durumlar, "DurumId", "DurumAd", @is.DurumId);
            ViewBag.PersonelId = new SelectList(db.Personeller, "PersonelId", "AdSoyad", @is.PersonelId);
            return View(@is);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)] // CKEditor HTML izni

        //sadece benim izin verdiğim sütunların doldurulmasını sağlar.
        public ActionResult Edit([Bind(Include = "IsId,Baslik,Aciklama,Tarih,PersonelId,DurumId")] Is @is)
        {
            if (ModelState.IsValid)  /*zorunlu alanlar doldurulmuşsa*/
            {
                /*Bu kaydın değiştiğini sisteme bildir*/
                db.Entry(@is).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DurumId = new SelectList(db.Durumlar, "DurumId", "DurumAd", @is.DurumId);
            ViewBag.PersonelId = new SelectList(db.Personeller, "PersonelId", "AdSoyad", @is.PersonelId);
            return View(@is);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Is @is = db.Isler.Find(id);
            if (@is == null) return HttpNotFound();
            return View(@is);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Is @is = db.Isler.Find(id);
            db.Isler.Remove(@is);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            /*veritabanı bağlantısını kapat ve belleği temizle*/
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}