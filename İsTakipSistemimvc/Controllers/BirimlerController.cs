using System.Data.Entity; // Include için gerekli
using System.Linq;
using System.Net;
using System.Web.Mvc;
using IsTakipSistemiMvc.Models;

namespace IsTakipSistemiMvc.Controllers
{

    /*kullanıcı giriş yapmadan bu kontrollera erişemez*/
    [Authorize]             
    public class BirimController : Controller
    {
        private IsTakipContext db = new IsTakipContext();

        // GET: Birimler
        public ActionResult Index()
        {
            //Personelleri dahil ediyoruz ki sayıları (Count) görebilelim
            var birimler = db.Birimler.Include("Personeller").ToList();
            return View(birimler);
        }

        // GET: Birimler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Detayda da personelleri yüklüyoruz
            Birim birim = db.Birimler.Include("Personeller").FirstOrDefault(b => b.BirimId == id);

            if (birim == null)
            {
                return HttpNotFound();
            }
            return View(birim);
        }

        // GET: Birimler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Birimler/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        //Bind ile sadece izin verdiğim alanların modele bağlanmasını sağlıyorum, güvenlik için
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

        // GET: Birimler/Edit/5
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

        // POST: Birimler/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BirimId,BirimAd")] Birim birim)
        {
            if (ModelState.IsValid)
            {
                //EF’ye bu kayıt güncellendi der

                db.Entry(birim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(birim);
        }

        // GET: Birimler/Delete/5
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

        // POST: Birimler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Birim birim = db.Birimler.Find(id);
            db.Birimler.Remove(birim);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Veritabanı bağlantısını düzgün kapatma:
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