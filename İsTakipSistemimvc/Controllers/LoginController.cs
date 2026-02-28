using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using IsTakipSistemiMvc.Models;

namespace IsTakipSistemiMvc.Controllers
{
    public class LoginController : Controller
    {
        IsTakipContext db = new IsTakipContext();

        // 1. Giriş Sayfasını Aç (GET)
        [HttpGet]
        public ActionResult Index()
        {
            
            if (db.Personeller.Count() == 0)
            {
                var birim = new Birim { BirimAd = "Yönetim" };
                var yetki = new YetkiTur { YetkiAd = "Yönetici" };

                db.Birimler.Add(birim);
                db.YetkiTurler.Add(yetki);
                db.SaveChanges();

                var admin = new Personel
                {
                    AdSoyad = "Süper Yönetici",
                    KullaniciAd = "admin",
                    Parola = "1234",
                    Telefon = "555",
                    BirimId = birim.BirimId,
                    YetkiTurId = yetki.YetkiTurId
                };

                db.Personeller.Add(admin);
                db.SaveChanges();
            }

            
            if (db.Durumlar.Count() == 0)
            {
                db.Durumlar.Add(new Durum { DurumAd = "Yapılıyor" });
                db.Durumlar.Add(new Durum { DurumAd = "Yapıldı" });
                db.Durumlar.Add(new Durum { DurumAd = "Ertelendi" });
                db.SaveChanges();
            }

            return View();
        }

        // 2. Giriş Yap Butonuna Basılınca (POST)
        [HttpPost]
        public ActionResult Index(Personel p)
        {
            if (p == null || string.IsNullOrEmpty(p.KullaniciAd) || string.IsNullOrEmpty(p.Parola))
            {
                ViewBag.Hata = "Lütfen bilgileri eksiksiz giriniz.";
                return View();
            }

            var bilgiler = db.Personeller.FirstOrDefault(x => x.KullaniciAd == p.KullaniciAd && x.Parola == p.Parola);

            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAd, false);
                
                return RedirectToAction("Index", "Dashboard");

            }
            else
            {
                ViewBag.Hata = "Kullanıcı adı veya şifre hatalı!";
                return View();
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }

    }
}