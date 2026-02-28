using System.Linq;
using System.Web.Mvc;
using IsTakipSistemiMvc.Models;

namespace IsTakipSistemiMvc.Controllers
{
    [Authorize] // Sadece giriş yapanlar görebilir!
    public class DashboardController : Controller
    {
        IsTakipContext db = new IsTakipContext();

        public ActionResult Index()
        {
            // İstatistikleri hesaplayıp View'a gönderiyoruz
            ViewBag.ToplamIs = db.Isler.Count();
            ViewBag.TamamlananIs = db.Isler.Count(x => x.Durum.DurumAd == "Yapıldı");
            ViewBag.DevamEdenIs = db.Isler.Count(x => x.Durum.DurumAd == "Yapılıyor");
            ViewBag.ToplamPersonel = db.Personeller.Count();

            return View();
        }
    }
}