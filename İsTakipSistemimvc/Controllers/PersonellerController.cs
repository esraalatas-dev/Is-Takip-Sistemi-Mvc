using System.Data.Entity; // Include için gerekli
using System.Linq;
using System.Net;
using System.Web.Mvc;
using IsTakipSistemiMvc.Models;

namespace IsTakipSistemiMvc.Controllers
{
    [Authorize]
    public class PersonelController : Controller
    {
        private IsTakipContext db = new IsTakipContext();

        // GET: Personeller
        public ActionResult Index()
        {
            var personeller = db.Personeller.Include(p => p.Birim).Include(p => p.YetkiTur);
            return View(personeller.ToList());
        }

        // GET: Personeller/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Include ile ilişkili verileri de çekiyoruz
            Personel personel = db.Personeller
                                  .Include(p => p.Birim)
                                  .Include(p => p.YetkiTur)
                                  .FirstOrDefault(p => p.PersonelId == id);

            if (personel == null)
            {
                return HttpNotFound();
            }
            return View(personel);
        }

        // GET: Personeller/Create
        public ActionResult Create()
        {
            ViewBag.BirimId = new SelectList(db.Birimler, "BirimId", "BirimAd");
            ViewBag.YetkiTurId = new SelectList(db.YetkiTurler, "YetkiTurId", "YetkiAd");
            return View();
        }

        // POST: Personeller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonelId,AdSoyad,KullaniciAd,Parola,Telefon,BirimId,YetkiTurId")] Personel personel)
        {
            if (ModelState.IsValid)
            {
                db.Personeller.Add(personel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BirimId = new SelectList(db.Birimler, "BirimId", "BirimAd", personel.BirimId);
            ViewBag.YetkiTurId = new SelectList(db.YetkiTurler, "YetkiTurId", "YetkiAd", personel.YetkiTurId);
            return View(personel);
        }

        // GET: Personeller/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personel personel = db.Personeller.Find(id);
            if (personel == null)
            {
                return HttpNotFound();
            }
            ViewBag.BirimId = new SelectList(db.Birimler, "BirimId", "BirimAd", personel.BirimId);
            ViewBag.YetkiTurId = new SelectList(db.YetkiTurler, "YetkiTurId", "YetkiAd", personel.YetkiTurId);
            return View(personel);
        }

        // POST: Personeller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonelId,AdSoyad,KullaniciAd,Parola,Telefon,BirimId,YetkiTurId")] Personel personel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BirimId = new SelectList(db.Birimler, "BirimId", "BirimAd", personel.BirimId);
            ViewBag.YetkiTurId = new SelectList(db.YetkiTurler, "YetkiTurId", "YetkiAd", personel.YetkiTurId);
            return View(personel);
        }

        // GET: Personeller/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personel personel = db.Personeller.Include(p => p.Birim).Include(p => p.YetkiTur).FirstOrDefault(p => p.PersonelId == id);
            if (personel == null)
            {
                return HttpNotFound();
            }
            return View(personel);
        }

        // POST: Personeller/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personel personel = db.Personeller.Find(id);
            db.Personeller.Remove(personel);
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